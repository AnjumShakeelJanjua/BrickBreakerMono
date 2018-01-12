using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float TotalTime = 180f;

    private float CurrentTime;
    private float timePassed;
    private int minutes;
    private int seconds;
    
    // Use this for initialization
    void Start()
    {
        CurrentTime = TotalTime;
    }



    void Update()
    {
        timePassed += Time.deltaTime;
        CurrentTime -= Time.deltaTime;
        minutes = (int)CurrentTime / 60;
        seconds = (int)CurrentTime % 60;
     //   Debug.Log(minutes + ":" + seconds + "Time");
        if (CurrentTime <= 0.0f)
        {
            timerEnded();
        }
        if (timePassed >= GameManager.instance.SpeedIncrementInterval)
        {
            Debug.Log("rotate");
            timePassed = 0;
            GameManager.instance.RotateBricks();
        }

    }

    void timerEnded()
    {
        Debug.Log("timeEnded");
    }
}
