using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantDeath : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.Death();
        }
        if(other.gameObject.tag == "Enemigo")
            Destroy(other.gameObject);   
        if (other.gameObject.tag == "Caja")
            Destroy(other.gameObject);
    }
}
