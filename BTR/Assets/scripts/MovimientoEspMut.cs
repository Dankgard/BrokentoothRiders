﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEspMut : MonoBehaviour {

    public GameObject startPoint;
    public GameObject endPoint;

    public bool colisionPlayer = false;

    public float enemySpeed;

    bool isGoingRight;

    public AtaqueEspMut rango;

    GameObject player;

    void Awake()
    {
        rango = GetComponentInChildren<AtaqueEspMut>();
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        if (!isGoingRight)
        {
            transform.position = startPoint.transform.position;
        }
        else
        {
            transform.position = endPoint.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rango.playerInRange == false)
        {
            if (!isGoingRight)
            {

                transform.localScale = new Vector3(1, 1, 1);


                transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position, enemySpeed * Time.deltaTime);
                if (transform.position == endPoint.transform.position)
                {
                    isGoingRight = true;
                    transform.localScale = new Vector3(-1, 1, 1);
                }

            }
            if (isGoingRight)
            {
                transform.localScale = new Vector3(-1, 1, 1);

                transform.position = Vector3.MoveTowards(transform.position, startPoint.transform.position, enemySpeed * Time.deltaTime);
                if (transform.position == startPoint.transform.position)
                {
                    isGoingRight = false;
                    transform.localScale = new Vector3(1, 1, 1);

                }

            }
        }
        else
        {
            if (player.transform.position.x <= transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (player.transform.position.x >= transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!colisionPlayer)
            {
                string[] arg = { gameObject.GetComponent<VidaEnemigo>().name };
                GameManager.instance_Tracker.RegisterEvent(Tracker.BTR_Tracker.EventType.HIT_FREQUENCY, arg);
            }

            colisionPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            colisionPlayer = false;
        }
    }

}
