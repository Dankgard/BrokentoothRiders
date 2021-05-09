using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Tracker;


public class TextScene : MonoBehaviour {
    public string escena;
    public int loadTime = 10;
	// Use this for initialization
	void Start () {
        Invoke("LoadScene", loadTime);
	}
	
	void LoadScene()
    {
        Debug.Log(BTR_Tracker.EventType.LEVEL_START);
        Debug.Log(GameManager.instance_Tracker);
        if (escena[7] == '1')
        { // para todos los niveles levelX_1
            string[] arg = {escena};
            GameManager.instance_Tracker.RegisterEvent(BTR_Tracker.EventType.LEVEL_START, arg);
            string[] param = { Time.deltaTime.ToString() };
            GameManager.instance_Tracker.RegisterEvent(BTR_Tracker.EventType.LEVEL_TIME, param);
        }

        SceneManager.LoadScene("Escenas/"+ escena);
    }
}
