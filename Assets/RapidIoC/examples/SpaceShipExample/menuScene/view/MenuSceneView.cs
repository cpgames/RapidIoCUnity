namespace cpGames.core.RapidIoC.examples.invadersExample.menu
{
    /// <summary>
    /// Menu is the first thing that loads when the game starts.
    /// </summary>
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
            StartGameSignal.RemoveCommand<StartGameCommand>();;
        }
        #endregion
    }
}