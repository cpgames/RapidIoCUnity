namespace cpGames.core.RapidMVC
{
    public abstract class MainSceneView : SceneView
    {
        #region Methods
        protected override void MapBindings()
        {
            Rapid.Bind<LoadSceneSignal>();
            Rapid.Bind<UnloadSceneSignal>();
            Rapid.Bind<SceneLoadedSignal>();
            Rapid.Bind<SceneUnloadedSignal>();
            LoadSceneSignal.AddCommand<LoadSceneCommand>();
            UnloadSceneSignal.AddCommand<UnloadSceneCommand>();
        }
        #endregion
    }
}