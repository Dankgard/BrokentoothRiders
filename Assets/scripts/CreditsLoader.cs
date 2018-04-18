using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditsLoader : MonoBehaviour {

    public string escena;
    public int loadTime;
    void Start()
    {
        Invoke("LoadScene", loadTime);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(escena);
    }
}
