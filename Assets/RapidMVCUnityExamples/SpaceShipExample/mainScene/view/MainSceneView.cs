using cpGames.core.RapidMVC.examples.invadersExample.game;

namespace cpGames.core.RapidMVC.examples.invadersExample
{
    [SceneRelationship(typeof(GameSceneView), SceneRelationshipType.Include)]
    public class MainSceneView : RapidMVC.MainSceneView
    {
        #region Methods
        protected override void MapBindings()
        {
            base.MapBindings();

            Rapid.Bind("Score", 0);
            Rapid.Bind<StartGameSignal>();
            Rapid.Bind<RestartSignal>();
        }

        protected override void UnmapBindings()
        {
            Rapid.Unbind("Score");
            Rapid.Unbind<StartGameSignal>();
            Rapid.Unbind<RestartSignal>();
        }
        #endregion
    }
}