namespace cpGames.core.RapidIoC.examples.sceneManagementExample
{
    [SceneRelationship(typeof(Scene2DependencyView), SceneRelationshipType.Include | SceneRelationshipType.Depend)]
    public class Scene2View : SceneView { }
}