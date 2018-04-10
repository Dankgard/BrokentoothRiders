using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarCaida : MonoBehaviour {

    public ComportamientoEdificios edif;
	void Start () {
        edif = GetComponentInParent<ComportamientoEdificios>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            edif.start = true;
        }
    }

}
