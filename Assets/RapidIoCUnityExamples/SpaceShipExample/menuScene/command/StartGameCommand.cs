namespace cpGames.core.RapidIoC.examples.invadersExample.menu
{
    // What happens when player want's to start new game
    public class StartGameCommand : CommandView
    {
        #region Properties
        // Game context
        public override string ContextName => CpUnityExtensions.GetSceneName<MenuSceneView>();
        #endregion

        #region Methods
        public override void Execute()
        {
            CpUnityExtensions.UnloadLevelAdditive<MenuSceneView>();
        }
        #endregion
    }
}