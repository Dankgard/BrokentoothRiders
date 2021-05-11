﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorrioBubble : MonoBehaviour {

    public int damage;
    public int destroyTime;

    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, destroyTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // TRACKER EVENT
            string[] param = { other.transform.position.x.ToString(), other.transform.position.y.ToString() };
            GameManager.instance_Tracker.RegisterEvent(Tracker.BTR_Tracker.EventType.DAMAGE_FREQUENCY, param);

            string[] arg = { "TorrioMutant" };
            GameManager.instance_Tracker.RegisterEvent(Tracker.BTR_Tracker.EventType.HIT_FREQUENCY, arg);

            GameManager.instance.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Suelo")
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
    }
}
