using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TextScene : MonoBehaviour {
    public string escena;
    public int loadTime = 10;
	// Use this for initialization
	void Start () {
        Invoke("LoadScene", loadTime);
	}
	
	void LoadScene()
    {
        if(escena[7] == "1") // para todos los niveles levelX_1
            GameManager.instance_Tracker.RegisterEvent(Tracker.BTR_Tracker.EventType.LEVEL_START);
        
        SceneManager.LoadScene(escena);
    }
}
