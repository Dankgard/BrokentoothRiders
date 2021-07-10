﻿using System.Collections;
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
        SceneManager.LoadScene("Escenas/"+ escena);
    }
}
