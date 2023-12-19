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
            Rapid.Bind<LoadSceneSignal>()
                .AddCommand(new LoadSceneCommand(), this);
            Rapid.Bind<UnloadSceneSignal>()
                .AddCommand(new UnloadSceneCommand(), this);
            Rapid.Bind<SceneLoadedSignal>();
            Rapid.Bind<SceneUnloadedSignal>();
        }

        protected override void UnmapBindings()
        {
            Rapid.Unbind<LoadSceneSignal>();
            Rapid.Unbind<UnloadSceneSignal>();
            Rapid.Unbind<SceneLoadedSignal>();
            Rapid.Unbind<SceneUnloadedSignal>();
        }
        #endregion
    }
}