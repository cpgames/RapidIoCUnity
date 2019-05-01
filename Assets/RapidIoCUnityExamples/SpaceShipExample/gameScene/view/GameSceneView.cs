using cpGames.core.RapidIoC.examples.invadersExample.gameOver;
using cpGames.core.RapidIoC.examples.invadersExample.menu;

namespace cpGames.core.RapidIoC.examples.invadersExample.game
{
    // Main game scene. It is a good idea to leave this clean of any game logic and serving two purposes:
    // 1. Mapping global and local bindings
    // 2. Setting up game scene
    [SceneRelationship(typeof(MenuSceneView), SceneRelationshipType.Include | SceneRelationshipType.Depend)]
    [SceneRelationship(typeof(GameOverSceneView), SceneRelationshipType.Depend)]
    public class GameSceneView : SceneView
    {
        #region Properties
        [Inject] public AddScoreSignal AddScoreSignal { get; set; }
        [Inject] public GameOverSignal GameOverSignal { get; set; }
        [Inject] public RestartSignal RestartSignal { get; set; }
        [Inject] public PlayerHitSignal PlayerHitSignal { get; set; }
        [Inject] public EnemyHitSignal EnemyHitSignal { get; set; }
        #endregion

        #region Methods
        protected override void MapBindings()
        {
            base.MapBindings();

            Rapid.Bind<AddScoreSignal>(ContextName);
            Rapid.Bind<GameOverSignal>(ContextName);
            Rapid.Bind<PlayerHitSignal>(ContextName);
            Rapid.Bind<EnemyHitSignal>(ContextName);
            Rapid.Bind("EntityRoot", transform.Find("EntityRoot").gameObject, ContextName);
            AddScoreSignal.AddCommand<AddScoreCommand>();
            PlayerHitSignal.AddCommand<PlayerHitCommand>();
            EnemyHitSignal.AddCommand<EnemyHitCommand>();
            GameOverSignal.AddCommand<GameOverCommand>();
        }

        protected override void UnmapBindings()
        {
            Rapid.Unbind<AddScoreSignal>(ContextName);
            Rapid.Unbind<GameOverSignal>(ContextName);
            Rapid.Unbind<PlayerHitSignal>(ContextName);
            Rapid.Unbind<EnemyHitSignal>(ContextName);
            Rapid.Unbind("EntityRoot", ContextName);
        }
        #endregion
    }
}