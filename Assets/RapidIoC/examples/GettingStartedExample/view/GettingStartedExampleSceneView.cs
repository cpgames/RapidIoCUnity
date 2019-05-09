using cpGames.core.RapidIoC;
public class GettingStartedExampleSceneView : MainSceneView
{
    protected override void MapBindings()
    {
        base.MapBindings();
        Rapid.Bind<UpdateSphereSignal>(ContextName);
    }

    protected override void UnmapBindings()
    {
        base.UnmapBindings();
        Rapid.Unbind<UpdateSphereSignal>(ContextName);
    }
}