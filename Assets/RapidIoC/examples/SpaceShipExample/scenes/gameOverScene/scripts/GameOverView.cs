namespace cpGames.core.RapidIoC.examples.invadersExample.gameOver
{
    public class GameOverView : ComponentView
    {
        #region Properties
        [Inject] public RestartSignal RestartSignal { get; set; }
        #endregion

        #region Methods
        public void Restart()
        {
            RestartSignal.Dispatch();
        }
        #endregion
    }
}