﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour {

    public static SoundManager instance = null;

    public AudioClip level1;
    public AudioClip level2;
    public AudioClip level3;
    public AudioClip level4;
    public AudioClip level5;
    public AudioClip menu;
    public AudioClip boss;
    public AudioClip credits;
    public AudioClip nothing;
 
    string lastScene ="";

    bool cambiaMusica;

    Dictionary<string,AudioClip> music;
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

        music = new Dictionary<string, AudioClip>
        {
            { "level0_1", nothing},
            { "level0_2", nothing},
            { "level0_3", nothing},
            { "level0_4", nothing},
            { "level0_5", nothing},
            { "level0_6", nothing},
            { "credits", credits },
            { "level1_1", level1 },
            { "level1_2", level1 },
            { "level1_3", boss },
            { "level1_text", nothing },
            { "level2_1", level2 },
            { "level2_text", nothing },
            { "level3_1", level3 },
            { "level3_2", level3 },
            { "level3_3", boss },
            { "level3_text", nothing },
            { "level4_1", level4 },
            { "level4_2", level4 },
            { "level4_3", boss },
            { "level4_text", nothing },
            { "level5_1", level5 },
            { "level5_2", level5 },
            { "level5_beforeboss", nothing },
            { "level5_3", boss },
            { "level5_text", nothing },
            { "Menu Principal", menu },
            { "Menu", menu }
        };   
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
        Scene currentScene = scene;

        if (lastScene == "")
        {
            cambiaMusica = true;
        }
        else if (music[lastScene].Equals(music[currentScene.name]) == false)
        {
            cambiaMusica = true;
        }
        else
            cambiaMusica = false;

        if (cambiaMusica)
        {
            source.clip = music[currentScene.name];
            source.Play();
        }

        lastScene = scene.name;
    }

    public void PlaySound(AudioClip sound, float volume)
    {
        source.PlayOneShot(sound, volume);
    }
}
