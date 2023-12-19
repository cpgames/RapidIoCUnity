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
        public override string ContextName => SceneName;
        [Inject] public LoadSceneSignal LoadSceneSignal { get; set; }
        [Inject] public UnloadSceneSignal UnloadSceneSignal { get; set; }
        [Inject] public SceneLoadedSignal SceneLoadedSignal { get; set; }
        [Inject] public SceneUnloadedSignal SceneUnloadedSignal { get; set; }

        public abstract string SceneName { get; }
        #endregion

        #region Listeners
        public virtual void OnSceneLoaded(SceneView sceneView)
        {
            if (_syncingAttribute == null)
            {
                return;
            }
            if (_syncingAttribute.SceneName == sceneView.SceneName &&
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

            var sortedList = GetType().GetAttributes<SceneRelationshipAttribute>();
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
                DispatchSceneLoadedSignal();
                return;
            }

            _syncingAttribute = _scenesToSync.Dequeue();
            if ((_syncingAttribute.Relationship & SceneRelationshipType.Exclude) != 0)
            {
                UnloadSceneSignal.Dispatch(_syncingAttribute.SceneName);
            }
            else if ((_syncingAttribute.Relationship & SceneRelationshipType.Include) != 0)
            {
                LoadSceneSignal.Dispatch(_syncingAttribute.SceneName);
            }
            SyncNext();
        }

        protected virtual void DispatchSceneLoadedSignal()
        {
            SceneLoadedSignal.Dispatch(this);
        }

        protected override void OnDestroy()
        {
            var atts = GetType().GetAttributes<SceneRelationshipAttribute>(false);
            foreach (var att in atts)
            {
                if ((att.Relationship & SceneRelationshipType.Depend) != 0)
                {
                    UnloadSceneSignal.Dispatch(att.SceneName);
                }
            }
            UnmapBindings();
            Resources.UnloadUnusedAssets();
            SceneUnloadedSignal.Dispatch(SceneName);
            base.OnDestroy();
        }

        protected virtual void MapBindings() { }

        protected virtual void UnmapBindings() { }
        #endregion
    }
}