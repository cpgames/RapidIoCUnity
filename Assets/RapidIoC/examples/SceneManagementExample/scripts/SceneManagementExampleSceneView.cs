using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace cpGames.core.RapidIoC.examples.sceneManagementExample
{
    [SceneRelationship(typeof(Scene1View), SceneRelationshipType.Include)]
    public class SceneManagementExampleSceneView : MainSceneView
    {
        #region Fields
        private readonly List<Type> _scenesLoaded = new List<Type>();

        public Text textPrefab;
        public Transform textRoot;
        #endregion

        #region Listeners
        public override void OnSceneLoaded(SceneView sceneView)
        {
            base.OnSceneLoaded(sceneView);
            _scenesLoaded.Add(sceneView.GetType());

            var sceneName = CpUnityExtensions.GetSceneName(sceneView.GetType());
            var text = textRoot.AddChild(textPrefab);
            text.name = sceneName;
            text.text = sceneName;
        }

        public void OnSceneUnloaded(Type sceneType)
        {
            if (_scenesLoaded.Contains(sceneType))
            {
                _scenesLoaded.Remove(sceneType);
                var child = textRoot.Find(CpUnityExtensions.GetSceneName(sceneType));
                if (child != null)
                {
                    Destroy(child.gameObject);
                }
            }
        }
        #endregion

        #region Methods
        public void ToggleScene1()
        {
            ToggleSceneInternal<Scene1View>();
        }

        public void ToggleScene2()
        {
            ToggleSceneInternal<Scene2View>();
        }

        public void ToggleScene3()
        {
            ToggleSceneInternal<Scene3View>();
        }

        private void ToggleSceneInternal<TScene>() where TScene : SceneView
        {
            if (!_scenesLoaded.Contains(typeof(TScene)))
            {
                CpUnityExtensions.LoadLevelAdditive<TScene>();
            }
            else
            {
                CpUnityExtensions.UnloadLevelAdditive<TScene>();
            }
        }
        #endregion
    }
}