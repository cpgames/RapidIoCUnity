namespace cpGames.core.RapidMVC.examples.invadersExample.gameOver
{
    // What happens when player want's to restart the game
    public class RestartCommand : CommandView
    {
        #region Properties
        // Current score
        [Inject("Score")] public int Score { get; set; }
        // Game context
        public override string ContextName => CpUnityExtensions.GetSceneName<GameOverSceneView>();
        #endregion

        #region Methods
        public override void Execute()
        {
            Rapid.Bind("Score", 0);
            CpUnityExtensions.UnloadLevelAdditive<GameOverSceneView>();
        }
        #endregion
    }
}