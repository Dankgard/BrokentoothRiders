using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueMutante : MonoBehaviour
{

    public bool playerInRange = false;
    public MovimientoMutante mov;
    GameObject player;

    public AudioClip attackSound;

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
            SoundManager.instance.PlaySound(attackSound, 0.25f);
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
