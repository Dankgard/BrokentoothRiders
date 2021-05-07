﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Tracker;

public class soundtest : MonoBehaviour
{
    private string path = "Files/BTR_SESSIONS.json";
    private string[] parametros;
    private BTR_Tracker tracker;

    void Start () {
        tracker = new BTR_Tracker();
        parametros = new string[10];
        tracker.SetFilePath(path);
        tracker.RegisterEvent(BTR_Tracker.EventType.SESSION_START);
        parametros[0] = "0.5";
        tracker.RegisterEvent(BTR_Tracker.EventType.LEVEL_START, parametros);
    }

    void OnApplicationQuit()
    {
        tracker.RegisterEvent(BTR_Tracker.EventType.LEVEL_END);
        tracker.RegisterEvent(BTR_Tracker.EventType.SESSION_END);
    }
}
