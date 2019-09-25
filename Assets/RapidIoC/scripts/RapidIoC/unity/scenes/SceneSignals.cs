using System;

namespace cpGames.core.RapidIoC
{
    public class LoadSceneSignal : Signal<Type>
    {
        #region Methods
        public void Dispatch<TScene>() where TScene : SceneView
        {
            Dispatch(typeof(TScene));
        }
        #endregion
    }

    public class SceneLoadedSignal : Signal<SceneView> { }

    public class UnloadSceneSignal : Signal<Type> { }

    public class SceneUnloadedSignal : Signal<Type> { }
}