namespace cpGames.core.RapidMVC.examples.invadersExample.game
{
    // What happens when enemy is hit by player's bolt
    public class EnemyHitCommand : CommandView<IEnemy>
    {
        #region Properties
        // We dispatch this signal to notify that score needs to be increased
        [Inject] public AddScoreSignal AddScoreSignal { get; set; }
        // Game context
        public override string ContextName => CpUnityExtensions.GetSceneName<GameSceneView>();
        #endregion

        #region Methods
        public override void Execute(IEnemy enemy)
        {
            // Kill the enemy and dispatch AddScore signal with whatever score the enemy is worth
            enemy.Kill(true);
            AddScoreSignal.Dispatch(enemy.Score);
        }
        #endregion
    }
}