﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemiga : MonoBehaviour {

    Rigidbody2D missileRB;

    public float speed;

    Transform player;

    public float vidaBala;

    public int bulletDamage;

    public string typeEnemy;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        missileRB = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        if (player.localPosition.x < transform.localPosition.x)
        {
            missileRB.velocity = new Vector2(-speed, missileRB.velocity.y);
            GetComponent<SpriteRenderer>().flipY = false;
        }
        else
        {
            missileRB.velocity = new Vector2(speed, missileRB.velocity.y);
            GetComponent<SpriteRenderer>().flipY = true;
        }
        Destroy(gameObject, vidaBala);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
            Destroy(gameObject);
        else if (collision.gameObject.tag == "Player")
        {
            // TRACKER EVENT
            string[] param = { collision.transform.position.x.ToString(), collision.transform.position.y.ToString()};
            GameManager.instance_Tracker.RegisterEvent(Tracker.BTR_Tracker.EventType.DAMAGE_FREQUENCY, param);

            string[] arg = { typeEnemy };
            GameManager.instance_Tracker.RegisterEvent(Tracker.BTR_Tracker.EventType.HIT_FREQUENCY, arg);

            GameManager.instance.TakeDamage(bulletDamage);
            Destroy(gameObject);
            Debug.Log("Player recibe daño");
        }
        else if (collision.gameObject.tag == "Bala")
            Destroy(gameObject);
    }
}
