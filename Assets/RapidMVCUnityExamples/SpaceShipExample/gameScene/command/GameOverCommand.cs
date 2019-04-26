using cpGames.core.RapidMVC.examples.invadersExample.gameOver;

namespace cpGames.core.RapidMVC.examples.invadersExample.game
{
    public class GameOverCommand : CommandView
    {
        #region Properties
        // Game context
        public override string ContextName => CpUnityExtensions.GetSceneName<GameSceneView>();
        #endregion

        #region Methods
        public override void Execute()
        {
            CpUnityExtensions.LoadLevelAdditive<GameOverSceneView>();
        }
        #endregion
    }
}