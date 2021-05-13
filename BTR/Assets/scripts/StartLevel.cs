using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tracker;

public class StartLevel : MonoBehaviour {
    public string escena;
    // Use this for initialization
    void Start () {
        string[] arg = { escena };
        GameManager.instance_Tracker.RegisterEvent(BTR_Tracker.EventType.LEVEL_START, arg);
        GameManager.instance.resetLevelTime();
        string[] param = { GameManager.instance.getLevelTime().ToString() };
        GameManager.instance_Tracker.RegisterEvent(BTR_Tracker.EventType.LEVEL_TIME, param);
    }
}
