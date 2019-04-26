namespace cpGames.core.RapidMVC.examples.invadersExample.game
{
    // What happens when we want to add player's score
    public class AddScoreCommand : CommandView<int>
    {
        #region Properties
        // Current score
        [Inject("Score")] public int Score { get; set; }
        // Game context
        public override string ContextName => CpUnityExtensions.GetSceneName<GameSceneView>();
        #endregion

        #region Methods
        public override void Execute(int score)
        {
            // add score and re-bind it to "Score" binding.
            // This is not optimal from performance standpoint, and merely serves as an example.
            // Ideally you would want to define a class like GameModel which contains score field,
            // and increment it that way without re-binding.
            Rapid.Bind("Score", Score + score);
        }
        #endregion
    }
}