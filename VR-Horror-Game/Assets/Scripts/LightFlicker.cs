using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [SerializeField] Light pointLight;

    [SerializeField] Light spotLight;

    [SerializeField] float maxIntensity = 2f;

    [SerializeField] float maxOnTime = 5f;
    [SerializeField] float maxOffTime = 0.5f;
    [SerializeField] float minOnTime = 1f;
    [SerializeField] float minOffTime = 0.1f;

    float randomOnTime = 5f;
    float randomOffTime = 0.1f;

    bool isLightOn = true;

    float currentTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (pointLight != null) pointLight.intensity = maxIntensity;
        else Debug.Log("assign point light in inspector");

        if (spotLight != null) spotLight.intensity = maxIntensity;
        else Debug.Log("assign spot light in inspector");

        randomOffTime = maxOffTime;
        randomOnTime = maxOnTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        SimpleFlicker();
    }

    void SimpleFlicker()
    {
        if (isLightOn)
        {
            if (currentTime >= randomOnTime)
            {
                randomOffTime = Random.Range(minOffTime, maxOffTime);
                ToggleLight();
            }
        }
        else
        {
            if (currentTime >= randomOffTime)
            {
                randomOnTime = Random.Range(minOnTime, maxOnTime);
                ToggleLight();
            }
        }
    }

    void ToggleLight()
    {
        currentTime = 0;
        isLightOn = !isLightOn;

        pointLight.intensity = isLightOn ? maxIntensity : 0;
        spotLight.intensity = isLightOn ? maxIntensity : 0;
    }
}
