namespace cpGames.core.RapidMVC.examples.invadersExample.game
{
    // What happens when player is hit by enemy's bolt
    public class PlayerHitCommand : CommandView<IPlayer>
    {
        #region Properties
        // Game context
        public override string ContextName => CpUnityExtensions.GetSceneName<GameSceneView>();
        #endregion

        #region Methods
        public override void Execute(IPlayer player)
        {
            // Kill the player
            player.Kill(true);
        }
        #endregion
    }
}