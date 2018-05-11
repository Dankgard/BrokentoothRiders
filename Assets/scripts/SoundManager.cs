using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour {

    public static SoundManager instance = null;

    public AudioClip level1;
    public AudioClip boss;

    AudioSource source;

	void Awake () {
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
        source = GetComponent<AudioSource>();
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
        switch(scene.name)
        {
            case "Menu Principal":
                break;
            case "level1_1":
                source.clip = level1;
                break;
            case "level2_1":
                break;
            case "level3_1":
                break;
            case "level4_1":
                break;
            case "level5_1":
                break;
            case "level1_3":
            case "level3_3":
            case "level4_3":
            case "level5_3":
                break;
            default:
                break;
        }
        source.Play();
    }

    public void PlaySound(AudioClip sound, float volume)
    {
        source.PlayOneShot(sound, volume);
    }
}
