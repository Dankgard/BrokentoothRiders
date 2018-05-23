using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aplastamiento : MonoBehaviour
{


    public GameObject jugador;


    public bool edificio = false;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            edificio = true;
            Debug.Log("funciona");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Aplastamiento")
        {
            Debug.Log("Muerte");
            GameManager.instance.Death();
        }

    }
}
