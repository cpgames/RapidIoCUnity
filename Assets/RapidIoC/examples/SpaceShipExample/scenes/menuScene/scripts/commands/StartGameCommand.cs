namespace cpGames.core.RapidIoC.examples.invadersExample.menu
{
    // What happens when player want's to start new game
    public class StartGameCommand : CommandView
    {
        #region Properties
        // Game context
        public override string ContextName => CpUnityExtensions.GetSceneName<MenuSceneView>();

        [Inject] public UnloadSceneSignal UnloadSceneSignal { get; set; }
        #endregion

        #region Methods
        public override void Execute()
        {
            UnloadSceneSignal.Dispatch(typeof(MenuSceneView));
        }
        #endregion
    }
}