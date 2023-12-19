using System;

namespace cpGames.core.RapidIoC
{
    public class LoadSceneSignal : Signal<string>
    {
        #region Methods
        public void Dispatch<TScene>() where TScene : SceneView
        {
            Dispatch(CpUnityExtensions.GetSceneName<TScene>());
        }

        public void Dispatch(Type sceneType)
        {
            Dispatch(CpUnityExtensions.GetSceneName(sceneType));
        }
        #endregion
    }

    public class SceneLoadedSignal : Signal<SceneView> { }

    public class UnloadSceneSignal : Signal<string> { }

    public class SceneUnloadedSignal : Signal<string> { }
}