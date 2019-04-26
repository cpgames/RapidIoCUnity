namespace cpGames.core.RapidMVC.examples.invadersExample.menu
{
    public class MenuSceneView : SceneView
    {
        #region Properties
        [Inject] public StartGameSignal StartGameSignal { get; set; }
        #endregion

        #region Methods
        protected override void MapBindings()
        {
            StartGameSignal.AddCommand<StartGameCommand>();
        }

        protected override void UnmapBindings()
        {
            //StartGameSignal.RemoveCommand< StartGameCommand>();
        }
        #endregion
    }
}