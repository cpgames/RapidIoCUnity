namespace cpGames.core.RapidIoC
{
    /// <summary>
    /// Your first scene in the game should derive from this class.
    /// It binds important signals later used by other SceneViews.
    /// </summary>
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

        protected override void UnmapBindings()
        {
            LoadSceneSignal.RemoveCommand<LoadSceneCommand>();
            UnloadSceneSignal.RemoveCommand<UnloadSceneCommand>();
            Rapid.Unbind<LoadSceneSignal>();
            Rapid.Unbind<UnloadSceneSignal>();
            Rapid.Unbind<SceneLoadedSignal>();
            Rapid.Unbind<SceneUnloadedSignal>();
        }
        #endregion
    }
}