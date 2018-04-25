using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergiaJugador : MonoBehaviour
{
    Text energia;
    SimpleHealthBar energyBar;

    GameManager manager;
   

    void Start()
    {
        energia = GetComponent<Text>();
        manager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        energyBar = GetComponent<SimpleHealthBar>();

    }

    void Update()
    {
        energyBar.UpdateBar(manager.currentEnergy, manager.initialEnergy);

    }
}
