using cpGames.core.RapidIoC.examples.invadersExample.gameOver;
using cpGames.core.RapidIoC.examples.invadersExample.menu;

namespace cpGames.core.RapidIoC.examples.invadersExample.game
{
    /// <summary>
    /// Game scene is where the actual gameplay happens. GameSceneView injects gameplay-specific signals and bindings.
    /// </summary>
    // MenuScene is loaded as soon as GameScene is loaded, and unloaded once GameScene is unloaded
    [SceneRelationship(typeof(MenuSceneView), SceneRelationshipType.Include | SceneRelationshipType.Depend)]
    // GameOverScene is unloaded once GameScene is unloaded (but not loaded at the start)
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
            // this is where we spawn our game entities
            Rapid.Bind("EntityRoot", transform.Find("EntityRoot").gameObject, ContextName);
            AddScoreSignal.AddCommand<AddScoreCommand>();
            PlayerHitSignal.AddCommand<PlayerHitCommand>();
            EnemyHitSignal.AddCommand<EnemyHitCommand>();
            GameOverSignal.AddCommand<GameOverCommand>();
        }

        protected override void UnmapBindings()
        {
            AddScoreSignal.RemoveCommand<AddScoreCommand>();
            PlayerHitSignal.RemoveCommand<PlayerHitCommand>();
            EnemyHitSignal.RemoveCommand<EnemyHitCommand>();
            GameOverSignal.RemoveCommand<GameOverCommand>();
            Rapid.Unbind<AddScoreSignal>(ContextName);
            Rapid.Unbind<GameOverSignal>(ContextName);
            Rapid.Unbind<PlayerHitSignal>(ContextName);
            Rapid.Unbind<EnemyHitSignal>(ContextName);
            Rapid.Unbind("EntityRoot", ContextName);
        }
        #endregion
    }
}