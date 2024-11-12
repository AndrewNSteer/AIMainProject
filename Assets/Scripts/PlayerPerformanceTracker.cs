using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceTracker : MonoBehaviour
{
    public float TimeToCompleteTask;
    public float shotsFired;
    public float shotsHit;
    public float shotsMissed;
    public float StartTime;
    public float ItemsCollected;
    public float TimeTakenToFinishLevel;

    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
    }

    void OnPlayerShoot()
    {
        shotsFired++;
    }

    void OnHitTarget()
    {
        shotsHit++;
    }

    void OnCollection()
    {

    }

    void LevelComplete()
    {
        TimeTakenToFinishLevel = Time.time - StartTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
