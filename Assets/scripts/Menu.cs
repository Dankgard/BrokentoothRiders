using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    

    public void Leve1_1()
    {
        SceneManager.LoadScene("level1_1");
    }
    public void Leve1_2()
    {
        SceneManager.LoadScene("level1_2");
    }
    public void Leve2_1()
    {
        SceneManager.LoadScene("level2_1");
    }
    public void Leve2_2()
    {
        SceneManager.LoadScene("level2_2");
    }
    public void Leve3_1()
    {
        SceneManager.LoadScene("level3_1");
    }
    public void Leve3_2()
    {
        SceneManager.LoadScene("level3_2");
    }
    public void Leve4_1()
    {
        SceneManager.LoadScene("level4_1");
    }
    public void Leve4_2()
    {
        SceneManager.LoadScene("level4_2");
    }
    public void Leve5_1()
    {
        SceneManager.LoadScene("level5_1");
    }
    public void Leve5_2()
    {
        SceneManager.LoadScene("level5_2");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
