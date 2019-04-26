namespace cpGames.core.RapidMVC.examples.invadersExample.menu
{
    public class MenuView : ComponentView
    {
        #region Properties
        [Inject] public StartGameSignal StartGameSignal { get; set; }
        #endregion

        #region Methods
        public void StartGame()
        {
            StartGameSignal.Dispatch();
        }
        #endregion
    }
}