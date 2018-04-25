using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour {

    Text vida;
    SimpleHealthBar healthBar;

    GameManager manager;

    void Start()
    {
        vida = GetComponent<Text>();
        manager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        healthBar = GetComponent<SimpleHealthBar>();


    }

    void Update()
    {
        healthBar.UpdateBar(manager.currentHealth, manager.initialHealth);


    }
}
