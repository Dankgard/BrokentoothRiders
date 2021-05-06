using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{

    public static Canvas instance = null;


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
            // Si ya existe un objeto Canvas, no necesitamos uno nuevo
            Destroy(this.gameObject);
        }
    }
}
