using System;

namespace cpGames.core.RapidMVC
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

    public class SceneLoadedSignal : Signal<Type> { }

    public class UnloadSceneSignal : Signal<Type> { }

    public class SceneUnloadedSignal : Signal<Type> { }
}