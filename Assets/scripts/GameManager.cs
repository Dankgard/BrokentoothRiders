using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    GameObject player;

    public int initialHealth = 100; //Vida al iniciar el juego
    public int currentHealth; //Vida a lo largo del nivel

    public int initialEnergy = 100;
    public int currentEnergy;

    bool alive = true;

    void Awake()
    {
        if (instance == null)
        {
            // Almacenamos la instancia actual
            instance = this;
            // Nos aseguramos de no destruir el objeto, es decir, 
            // de que persista, si cambiamos de escena
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // Si ya existe un objeto GameManager, no necesitamos uno nuevo
            Destroy(this.gameObject);
        }

        currentHealth = initialHealth; //asigna la cantidad predeterminada de vida a la vida actual
        currentEnergy = initialEnergy;
        player = GameObject.FindWithTag("Player").gameObject;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu Principal");
        }
    }

    public int Health()
    {
        return currentHealth;
    }

    public int Energy()
    {
        return currentEnergy;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; //resta el daño a la vida actual

        if (currentHealth > initialHealth)
        {
            currentHealth = initialHealth;
        }

        if (currentHealth <= 0 && alive) //si la vida es igual o menor a 0, llama al método Death
        {
            Death();
        }
    }

    public void TakeEnergy(int gasto)
    {
        currentEnergy -= gasto;

        if (currentEnergy > initialEnergy)
        {
            currentEnergy = initialEnergy;
        }
    }

    public void Death()
    {
        Destroy(player);
        alive = false;
        currentHealth = 0;
        Invoke("ReloadScene", 2);
    }

    public void ReloadScene()
    {
        currentHealth = initialHealth;
        currentEnergy = initialEnergy;
        alive = true;
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public bool Alive()
    {
        return alive;
    }

    public void StartLoadingScene(string escena)
    {
        StartCoroutine(LoadScene(escena));
    }
    
    IEnumerator LoadScene(string escena)
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(escena);
    }





}