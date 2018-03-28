using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TextScene : MonoBehaviour {
    public string escena;
	// Use this for initialization
	void Start () {
        Invoke("LoadScene", 10);
	}
	
	void LoadScene()
    {
        SceneManager.LoadScene(escena);
    }
}
