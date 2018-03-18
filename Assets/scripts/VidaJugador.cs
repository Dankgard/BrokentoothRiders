using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour {

    Text vida;

    void Start()
    {
        vida = GetComponent<Text>();
    }

    void Update()
    {
        vida.text = "Health: " + GameManager.instance.Health();

    }
}
