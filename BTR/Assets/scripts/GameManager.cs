using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Tracker;


public class GameManager : MonoBehaviour
{
    // TRACKER ASSETS
    public static BTR_Tracker instance_Tracker = null;
    private bool canQuit = false;

    public static GameManager instance = null;
    public GameObject player;

    public int initialHealth = 100; //Vida al iniciar el juego
    public int currentHealth; //Vida a lo largo del nivel

    public int initialEnergy = 100;
    public int currentEnergy;

    VidaJugador vida;
    EnergiaJugador energia;

    bool alive = true;
    public bool interfaz = true;

    public AudioClip hurtSound;

    // true escopeta, false fusil
    public bool shotgunActive;

    void Awake()
    {
        if (instance == null)
        {
            // Almacenamos la instancia actual
            instance = this;

            // BTR TRACKER
            instance_Tracker = new BTR_Tracker();
            instance_Tracker.SetFilePath("Files/BTR_SESSIONS_test.json");
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
    }
    void Start()
    {
        // BTR TRACKER
        instance_Tracker.RegisterEvent(BTR_Tracker.EventType.SESSION_START);
        Debug.Log("Inicia la sesion");
    }
    void OnApplicationQuit()
    {
        StartCoroutine("DelayedQuit");
        if (!canQuit)
        {
            Application.CancelQuit();
        }
    }

    IEnumerator DelayedQuit()
    {
        // BTR TRACKER
        string[] param = { Time.deltaTime.ToString() };
        // Esta es la linea que esta dando problemas
        instance_Tracker.RegisterEvent(BTR_Tracker.EventType.LEVEL_END);
        instance_Tracker.RegisterEvent(BTR_Tracker.EventType.SESSION_END);
        Debug.Log("Termina la sesion");

        // Wait for showSplashTimeout
        yield return new WaitForSeconds(2.5f);

        // Ahora si
        canQuit = true;
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
        player = GameObject.FindWithTag("Player").gameObject;

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
            // Carga el menu principal
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

    public bool ShotgunActive()
    {
        return shotgunActive;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; //resta el daño a la vida actual

        if (currentHealth > initialHealth)
        {
            currentHealth = initialHealth;
        }

        if (damage > 0)
        {
            SoundManager.instance.PlaySound(hurtSound, 1f);
        }

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

        // ESTE DE AQUI PENDIENTE

        // TRACKER EVENT
        //string[] param = { scene };
        //instance_Tracker.RegisterEvent(Tracker.BTR_Tracker.EventType.LEVEL_START, param);

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
        string[] param = { "empty" };
        if (instance_Tracker.TrackerRunning())
        {
            param[0] = Time.deltaTime.ToString();
            instance_Tracker.RegisterEvent(BTR_Tracker.EventType.LEVEL_END, param);
        }

        // TRACKER EVENT
        param[0] = escena;
        instance_Tracker.RegisterEvent(Tracker.BTR_Tracker.EventType.LEVEL_START, param);
        
        // TRACKER EVENT
        param[0] = Time.deltaTime.ToString();
        instance_Tracker.RegisterEvent(Tracker.BTR_Tracker.EventType.LEVEL_TIME, param);

        yield return new WaitForSeconds(time);
        if (escena != "level2_1")
        {
            currentHealth = initialHealth;
            currentEnergy = initialEnergy;
            vida.Reload(initialHealth);
            energia.Reload(initialEnergy);
        }
        SceneManager.LoadScene(escena);
    }





}