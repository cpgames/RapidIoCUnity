namespace cpGames.core.RapidIoC.examples.sceneManagementExample
{
    [SceneRelationship(typeof(Scene1View), SceneRelationshipType.Exclude)]
    [SceneRelationship(typeof(Scene2View), SceneRelationshipType.Exclude)]
    public class Scene3View : SceneView { }
}