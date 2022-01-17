using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    [SerializeField]  public int time;
    [SerializeField]  public int dayTime;
    [SerializeField]  private int dayLength = 20000;


    private void FixedUpdate()
    {
        time++;
        dayTime++;
        if(dayTime > dayLength)
        {
            dayTime = 0;
        }
    }


}
