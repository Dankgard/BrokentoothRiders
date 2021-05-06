using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigos : MonoBehaviour {

    public GameObject startPoint;
    public GameObject endPoint;

    public bool colisionPlayer = false;

    public float enemySpeed;

    bool isGoingRight;

    public DisparoEnemigo rango;

    public Animator anim;
    

    void Awake()
    {
        rango = GetComponentInChildren<DisparoEnemigo>();
        anim = GetComponent<Animator>();        
    }

    void Start () {        

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
	void Update () {        


        if (rango.playerInRange == false)
        {
            if (enemySpeed != 0)
            {
                anim.SetBool("Run", true);
                anim.SetBool("Idle", false);
            }

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
            anim.SetBool("Run", false);
            anim.SetBool("Idle", true);
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
