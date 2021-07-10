using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TrackerSpace;

public class CambiaEscena : MonoBehaviour {

    public string escena;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene(escena);

        if(escena == "level2_text")
        {
            GameManager.instance.resetWeaponUsageTime();
            GameManager.instance_Tracker.addTrackerEvent(Tracker.EventType.LEVEL_END);
        }

        GameManager.instance.FinishLevel();
    }

}