using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TrackerSpace;

public class StartLevel : MonoBehaviour {
    public string escena;
    // Use this for initialization
    void Start () {                    

        if (!GameManager.instance.getStartLevel())
        {
            string[] arg = { escena };
            Tracker.Instance.addTrackerEvent(Tracker.EventType.LEVEL_START, arg);

            GameManager.instance.resetLevelTime();

            GameManager.instance.resetWeaponUsageTime();
            GameManager.instance.StartLevel();
        }            
    }
}
