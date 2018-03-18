using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaqueteArmas : MonoBehaviour {

    public bool isShotgun = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            DisparoRex arma  = other.GetComponent<DisparoRex>();
            arma.shotgunActive = isShotgun;
            arma.WeaponChange();
            Destroy(gameObject);
        }
    }
}
