using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigos : MonoBehaviour
{

    public GameObject startPoint;
    public GameObject endPoint;
    public GameObject SouthPoint;
    public GameObject NorthPoint;
    public bool colisionPlayer = false;
    public float speedX, speedY;
    bool isGoingRight;
    public DisparoEnemigo rango;

    void Awake()
    {
        rango = GetComponentInChildren<DisparoEnemigo>();
    }

    void Start()
    {

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
        if (transform.position.y <= SouthPoint.position.y || transform.position.y >= NorthPoint.position.y)
        {
            speedY = -speedY;
        }
        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);

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
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
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