using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambiaEscena : MonoBehaviour {

    public string escena;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene(escena);

        if(escena == "level2_text")
        {
            GameManager.instance.resetWeaponUsageTime();
            string[] param = { GameManager.instance.getLevelTime().ToString() };
            GameManager.instance_Tracker.RegisterEvent(Tracker.BTR_Tracker.EventType.LEVEL_END, param);
        }
    }

}