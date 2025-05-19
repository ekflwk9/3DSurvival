using UnityEngine;

public class Sun : MonoBehaviour, IStart
{
    private float time;
    private Light sun;

    [Header("³·¿¡ ºû ±×¶óµ¥ÀÌ¼Ç")]
    [SerializeField] private Gradient sunColor;

    [Header("¹ã¿¡ ºû ±×¶óµ¥ÀÌ¼Ç")]
    [SerializeField] private Gradient moonColor;

    [Header("")]
    [SerializeField] private AnimationCurve intencity;

    private void Awake() => GameManager.startManager.Add(this);

    public void OnStart()
    {
        sun = GetComponent<Light>();
    }

    private void Update()
    {
        time += 0.1f;
        if (time > 360) time = 0;
        this.transform.rotation = Quaternion.Euler(time, 0, 0);

        ChangeColor();
    }

    private void ChangeColor()
    {
        if (time > 200)
        {
            sun.color = moonColor.Evaluate(time);
        }

        else if (time > 0)
        {
            sun.color = sunColor.Evaluate(time);
        }

        RenderSettings.ambientIntensity = intencity.Evaluate(time);
        RenderSettings.reflectionIntensity = intencity.Evaluate(time);
    }

    //private void MoveSun()
    //{
    //    time = (time + Time.smoothDeltaTime) % 1;

    //    UpdateLighting(sun, afternoonColor, sunIntensity);
    //    UpdateLighting(moon, moonColor, moonIntensity);

    //    RenderSettings.ambientIntensity = lightIntensity.Evaluate(time);
    //    RenderSettings.reflectionIntensity = reflectionIntensity.Evaluate(time);
    //}

    //private void UpdateLighting(Light _lightSource, Gradient _gradient, AnimationCurve _intensityCurve)
    //{
    //    float intensity = _intensityCurve.Evaluate(time);

    //    _lightSource.transform.eulerAngles = (time - (_lightSource == sun ? 0.25f : 0.75f)) * wtf * 4f;
    //    _lightSource.color = _gradient.Evaluate(time);
    //    _lightSource.intensity = intensity;

    //    GameObject plne = _lightSource.gameObject;
    //    if (_lightSource.intensity == 0 && plne.activeInHierarchy)
    //    {
    //        plne.SetActive(false);
    //    }

    //    else if (_lightSource.intensity > 0 && !plne.activeSelf)
    //    {
    //        plne.SetActive(true);
    //    }
    //}
}
