using System;
using System.Collections.Generic;
using cpGames.core.CpReflection;
using UnityEngine;

namespace cpGames.core.RapidIoC
{
    public abstract class SceneView : ComponentView
    {
        #region Fields
        private Queue<SceneRelationshipAttribute> _scenesToSync;
        private SceneRelationshipAttribute _syncingAttribute;
        #endregion

        #region Properties
        public override string ContextName => CpUnityExtensions.GetSceneName(GetType());
        [Inject] public LoadSceneSignal LoadSceneSignal { get; set; }
        [Inject] public UnloadSceneSignal UnloadSceneSignal { get; set; }
        [Inject] public SceneLoadedSignal SceneLoadedSignal { get; set; }
        [Inject] public SceneUnloadedSignal SceneUnloadedSignal { get; set; }
        #endregion

        #region Listeners
        public virtual void OnSceneLoaded(Type sceneType)
        {
            if (_syncingAttribute == null)
            {
                return;
            }
            if (_syncingAttribute.SceneType == sceneType &&
                (_syncingAttribute.Relationship & SceneRelationshipType.Include) != 0)
            {
                SyncNext();
            }
        }
        #endregion

        #region Methods
        protected override void Awake()
        {
            base.Awake();
            MapBindings();

            var sortedList = GetType().GetAttributes<SceneRelationshipAttribute>(false);
            sortedList.Sort((x, y) => x.Order.CompareTo(y.Order));
            _scenesToSync = new Queue<SceneRelationshipAttribute>();
            sortedList.ForEach(x => _scenesToSync.Enqueue(x));
            SyncNext();
        }

        private void SyncNext()
        {
            if (_scenesToSync.Count == 0)
            {
                _syncingAttribute = null;
                Resources.UnloadUnusedAssets();
                SceneLoadedSignal.Dispatch(GetType());
                return;
            }

            _syncingAttribute = _scenesToSync.Dequeue();
            if ((_syncingAttribute.Relationship & SceneRelationshipType.Exclude) != 0)
            {
                UnloadSceneSignal.Dispatch(_syncingAttribute.SceneType);
                SyncNext();
            }
            else if ((_syncingAttribute.Relationship & SceneRelationshipType.Include) != 0)
            {
                LoadSceneSignal.Dispatch(_syncingAttribute.SceneType);
            }
            else
            {
                SyncNext();
            }
        }

        protected override void OnDestroy()
        {
            var atts = GetType().GetAttributes<SceneRelationshipAttribute>(false);
            foreach (var att in atts)
            {
                if ((att.Relationship & SceneRelationshipType.Depend) != 0)
                {
                    UnloadSceneSignal.Dispatch(att.SceneType);
                }
            }
            UnmapBindings();
            Resources.UnloadUnusedAssets();
            SceneUnloadedSignal.Dispatch(GetType());
            base.OnDestroy();
        }

        protected virtual void MapBindings() { }

        protected virtual void UnmapBindings() { }
        #endregion
    }
}