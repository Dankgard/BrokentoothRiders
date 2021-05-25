using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoBoss1 : MonoBehaviour
{

    public GameObject startPoint;
    public GameObject endPoint;

    public bool colisionPlayer = false;

    public float enemySpeed;
    float speed;
    public float jumpForce;
    float jump = 0;
    bool isGoingRight;
    bool moving = false;

    public DisparoBoss1 rango;

    SpriteRenderer sprite;
    Rigidbody2D rb;

    public float jumpFreq = 0.1f;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        speed = -enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (moving)
        {                 
            rb.velocity = new Vector2(speed, jump);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            colisionPlayer = true;

        if (collision.tag == "DirCollision")
        {
            if (!isGoingRight)
            {
                isGoingRight = true;
                sprite.flipX = true;
                speed = enemySpeed;
            }
            else
            {
                isGoingRight = false;
                sprite.flipX = false;
                speed = -enemySpeed;
            }
        }

        if(collision.tag == "JumpLimit")
        {
            jump = -jumpForce;
        }

        if(collision.tag == "Suelo" && jump == -jumpForce)
        {
            jump = 0;
        }


    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            colisionPlayer = false;
        }
    }

    public void StartMoving()
    {
        moving = true;
        InvokeRepeating("Jump", 3, jumpFreq);
    }

    void Jump()
    {
        jump = jumpForce;
    }
}
