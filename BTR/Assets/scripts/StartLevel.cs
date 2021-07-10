using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour {
    public string escena;
    // Use this for initialization
    void Start () {                    

        if (!GameManager.instance.getStartLevel())
        {
            string[] arg = { escena };
            GameManager.instance_Tracker.addTrackerEvent(TrackerSpace.Tracker.EventType.LEVEL_START, arg);

            GameManager.instance.resetLevelTime();

            GameManager.instance.resetWeaponUsageTime();
            GameManager.instance.StartLevel();
        }            
    }
}
