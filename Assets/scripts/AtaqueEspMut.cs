using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEspMut : MonoBehaviour
{

    public bool playerInRange = false;
    public MovimientoEspMut mov;
    GameObject player;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
    }

}
