using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    [SerializeField] private GameTime time;
    [SerializeField] private Light2D globalLight;
    [SerializeField] private Light2D redLight;

    private int timeUntilNightEnds = 3000;
    private int timeUntilDay = 5000;
    private int timeUntilDayEnds = 15000;
    private int timeUntilNight = 17000;
    
    void Update()
    {
        if(time.dayTime > timeUntilNight)
        {
            globalLight.intensity = 0.2f;
        } else if(time.dayTime > timeUntilDayEnds)
        {
            AddIntensityToGloballight(-0.001f);
        }
        else if (time.dayTime > timeUntilDay)
        {
            globalLight.intensity = 1f;
        }
        else if (time.dayTime > timeUntilNightEnds)
        {
            AddIntensityToGloballight(0.001f);
        }
    }


    private void AddIntensityToGloballight(float intensity)
    {
        globalLight.intensity += intensity;
        if (globalLight.intensity > 1)
        {
            globalLight.intensity = 1;
        }

    }
}
