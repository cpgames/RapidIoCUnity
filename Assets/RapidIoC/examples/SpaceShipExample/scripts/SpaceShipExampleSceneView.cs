using cpGames.core.RapidIoC.examples.invadersExample.game;

namespace cpGames.core.RapidIoC.examples.invadersExample
{
    [SceneRelationship(typeof(GameSceneView), SceneRelationshipType.Include)]
    public class SpaceShipExampleSceneView : RapidIoC.MainSceneView
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