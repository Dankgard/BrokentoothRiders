using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBoss1 : MonoBehaviour
{

    public GameObject startPoint;
    public GameObject endPoint;

    public bool colisionPlayer = false;

    public float enemySpeed;
    public float jumpForce;
    bool isGoingRight;

    public DisparoBoss1 rango;

    SpriteRenderer sprite;
    Rigidbody2D rb;

    public float jumpProb = 0.2f;
    float jumpNumber;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpNumber = Random.Range(0, 1);

        
        if (rango.playerInRange)
        {
            if (!isGoingRight)
            { 
                if(jumpNumber < jumpProb)
                    rb.AddForce(new Vector2 (-jumpForce, jumpForce));
            }
            else
            {

                if (jumpNumber < jumpProb)
                    rb.AddForce(new Vector2 (jumpForce, jumpForce));
            }
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            colisionPlayer = true;
        }

        if(collision.tag == "DirCollision")
        {
            if(!isGoingRight)
            {
                isGoingRight = true;
                sprite.flipX = true;
                rb.velocity = new Vector2(enemySpeed, 0);
            }
            else
            {
                isGoingRight = false;
                sprite.flipX = false;
                rb.velocity = new Vector2(-enemySpeed, 0);
            }
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
