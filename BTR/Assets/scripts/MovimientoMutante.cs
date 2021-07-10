using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMutante : MonoBehaviour
{

    public GameObject startPoint;
    public GameObject endPoint;

    public bool colisionPlayer = false;

    public float enemySpeed;
    float triggeredSpeed;

    bool isGoingRight;

    public AtaqueMutante rango;

    GameObject player;

    void Awake()
    {
        rango = GetComponentInChildren<AtaqueMutante>();
        triggeredSpeed = enemySpeed+3;
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
                transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position, triggeredSpeed * Time.deltaTime);
            }
            else if (player.transform.position.x >= transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position = Vector3.MoveTowards(transform.position, startPoint.transform.position, triggeredSpeed * Time.deltaTime);
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
                GameManager.instance_Tracker.addTrackerEvent(TrackerSpace.Tracker.EventType.ENEMY_MAKES_DAMAGE, arg);
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

