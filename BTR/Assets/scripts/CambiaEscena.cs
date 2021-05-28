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
        {
            string[] para = { GameManager.instance.GetNumBoxes().ToString(), SceneManager.GetActiveScene().name };
            GameManager.instance_Tracker.RegisterEvent(Tracker.Practica_Final_Tracker.EventType.END_LEVEL, para);
            GameManager.instance.ResetBoxes();
            SceneManager.LoadScene(escena);
            GameManager.instance.sceneChanged = true;

        }
    }

}