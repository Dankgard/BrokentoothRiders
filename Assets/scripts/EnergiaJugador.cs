using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergiaJugador : MonoBehaviour
{

    Text energia;

    void Start()
    {
        energia = GetComponent<Text>();
    }

    void Update()
    {
        energia.text = "Energy: " + GameManager.instance.Energy();

    }
}
