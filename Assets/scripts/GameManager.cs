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

    VidaJugador vida;
    EnergiaJugador energia;

    bool alive = true;
    public bool interfaz = true;

    public AudioClip hurtSound;

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

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name != "level2_1")
        {
            vida = GameObject.FindWithTag("healthbar").GetComponent<VidaJugador>();
            energia = GameObject.FindWithTag("energybar").GetComponent<EnergiaJugador>();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEngine.Cursor.visible = true;
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

        if(damage>0)
            SoundManager.instance.PlaySound(hurtSound, 1f);

        vida.LoadHealth();

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

        energia.LoadEnergy();
    }

    public void Death()
    {
        if (alive)
        {
            Destroy(player);
            alive = false;
            currentHealth = 0;
            ReloadScene();
        }
    }

    public void ReloadScene()
    {
        alive = true;
        string scene = SceneManager.GetActiveScene().name;
        StartLoadingScene(scene, 2);
    }

    public bool Alive()
    {
        return alive;
    }

    public void StartLoadingScene(string escena, int time)
    {
        StartCoroutine(LoadScene(escena,time));
    }
    
    IEnumerator LoadScene(string escena, int time)
    {
        yield return new WaitForSeconds(time);
        currentHealth = initialHealth;
        currentEnergy = initialEnergy;
        vida.Reload(initialHealth);
        energia.Reload(initialEnergy);
        SceneManager.LoadScene(escena);
    }





}