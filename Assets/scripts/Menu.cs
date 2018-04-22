using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    

    public void Leve1()
    {
        SceneManager.LoadScene("level1_1");
    }
    public void Leve2()
    {
        SceneManager.LoadScene("level2_1");
    }
    public void Leve3()
    {
        SceneManager.LoadScene("level3_1");
    }
    public void Leve4()
    {
        SceneManager.LoadScene("level4_1");
    }
    public void Leve5()
    {
        SceneManager.LoadScene("level5_1");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
