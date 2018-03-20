using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaqueteEnergia : MonoBehaviour {

    public int energy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.TakeEnergy(-energy);
            Destroy(gameObject);
        }
    }
}
