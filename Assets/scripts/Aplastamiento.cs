using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aplastamiento : MonoBehaviour {

    public GameObject jugador;	

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Aplastamiento")
        {
            Debug.Log("Muerte");
            GameManager.instance.Death();
        }
    }   

}
