using System.Collections;
using cpGames.core.RapidIoC;
using UnityEngine;
public class SphereControllerView : ComponentView
{
    private readonly SphereModel _model = new SphereModel();
    private float _timeIntoAnimation = 0f;

    public float updateInterval = 3.0f;
    public float animationDuration = 30.0f;
    public Color colorStart = Color.white;
    public Color colorEnd = Color.red;
    public float sizeStart = 1.0f;
    public float sizeEnd = 10.0f;

    [Inject]
    public UpdateSphereSignal UpdateSphereSignal { get; set; }

    private void Start()
    {
        StartCoroutine(UpdateSphereModel());
    }

    private IEnumerator UpdateSphereModel()
    {
        _model.sphereColor = Color.Lerp(colorStart, colorEnd, _timeIntoAnimation / animationDuration);
        _model.sphereSize = Mathf.Lerp(sizeStart, sizeEnd, _timeIntoAnimation / animationDuration);
        UpdateSphereSignal.Dispatch(_model);
        yield return new WaitForSeconds(updateInterval);
        _timeIntoAnimation = (_timeIntoAnimation + updateInterval) % animationDuration;
        StartCoroutine(UpdateSphereModel());
    }
}