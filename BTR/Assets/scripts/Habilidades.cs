﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidades : MonoBehaviour
{
    public Granada granada;
    public Escudo escudo;

    public int gasto;

    public int velGranada;

    public Transform grenadePoint;

    SpriteRenderer player;

    bool activatedShield = false;


    private void Start()
    {
        player = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.Energy() > 0)
        {
            if (Input.GetKeyDown(KeyCode.E) && GameManager.instance.Energy() >= gasto)
            {
                GameManager.instance.TakeEnergy(gasto);
                granada.enemy = "PLAYER";
                Granada boom = Instantiate(granada, grenadePoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                Rigidbody2D rb = boom.GetComponent<Rigidbody2D>();

                if (player.flipX)
                    rb.velocity = new Vector2(-velGranada, velGranada);
                else
                    rb.velocity = new Vector2(velGranada, velGranada);

                Debug.Log("Tracker: grenade usage");
                GameManager.instance_Tracker.RegisterEvent(Tracker.Practica_Final_Tracker.EventType.GRENADE_USAGES);

            }

            if (Input.GetKeyDown(KeyCode.Q) && !activatedShield && GameManager.instance.Energy() >= gasto)
            {
                GameManager.instance.TakeEnergy(gasto);
                Escudo nokiaShield = Instantiate(escudo, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                activatedShield = true;
                Invoke("ActivateShield", nokiaShield.shieldLength);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Tracker: Use ability no energy");
            GameManager.instance_Tracker.RegisterEvent(Tracker.Practica_Final_Tracker.EventType.USE_ABILITY_NO_ENERGY);
        }
    }

    public bool getShieldActive() { return activatedShield; }
    void ActivateShield()
    {
        activatedShield = false;
    }
}
