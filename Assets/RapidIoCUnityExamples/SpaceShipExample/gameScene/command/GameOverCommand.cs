using cpGames.core.RapidIoC.examples.invadersExample.gameOver;

namespace cpGames.core.RapidIoC.examples.invadersExample.game
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