using cpGames.core.RapidIoC;
using UnityEngine;
public class SphereView : ComponentModelView<SphereModel>
{
    [Inject]
    public UpdateSphereSignal UpdateSphereSignal { get; set; }

    public void OnUpdateSphere(SphereModel model)
    {
        Model = model;
        UpdateModel();
    }

    protected override void UpdateModel()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Model.sphereColor);
        transform.localScale = Vector3.one * Model.sphereSize;
    }
}