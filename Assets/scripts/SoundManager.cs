using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance = null;

    AudioSource source;

	void Awake () {
        if (instance == null)
        {
            // Almacenamos la instancia actual
            instance = this;
            // Nos aseguramos de no destruir el objeto, es decir, 
            // de que persista, si cambiamos de escena
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // Si ya existe un objeto GameManager, no necesitamos uno nuevo
            Destroy(this.gameObject);
        }
        source = GetComponent<AudioSource>();
	}
	

    public void PlaySound(AudioClip sound, float volume)
    {
        source.PlayOneShot(sound, volume);
    }
}
