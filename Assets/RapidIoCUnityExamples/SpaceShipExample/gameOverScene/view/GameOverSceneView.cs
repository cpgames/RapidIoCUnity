namespace cpGames.core.RapidIoC.examples.invadersExample.gameOver
{
    public class GameOverSceneView : SceneView
    {
        #region Properties
        [Inject] public RestartSignal RestartSignal { get; set; }
        #endregion

        #region Methods
        protected override void MapBindings()
        {
            RestartSignal.AddCommand<RestartCommand>();
        }

        protected override void UnmapBindings()
        {
            RestartSignal.RemoveCommand<RestartCommand>();
        }
        #endregion
    }
}