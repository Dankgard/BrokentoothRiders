using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoProtagonista : MonoBehaviour {

	public float speed;
    float moved = 0f;

	Rigidbody2D rb;

    public float climbSpeed;

    public float RepeleX;
    public float RepeleY;
    public int repelDamage;

    public float tiempoSincont;

    bool control = true;

    bool canClimb = false;

    void Start(){
		rb = GetComponent<Rigidbody2D> ();
        
        control = true;
    }
    void Update()
    {
        if (GameManager.instance.Alive())
        {
            if (control)
            {
                Movimiento();
            }
            else
            {
                Invoke("Booleano", tiempoSincont);
            }

            if (canClimb)
                Ladder();
        }
        
    }

    public void Movimiento()
    {
        moved = Input.GetAxis("Horizontal");
        if (moved < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moved > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        rb.velocity = new Vector2(moved * speed, rb.velocity.y);
    }

    void Ladder()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0, 1) * climbSpeed;
            rb.gravityScale = 0;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0, -1) * climbSpeed;
            rb.gravityScale = 0;
        }
        rb.gravityScale = 1;
    }


    public void Booleano()
    {
        control = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemigo")
        {
            control = false;

            if (GetComponent<SpriteRenderer>().flipX == false) {
                rb.velocity = new Vector2(-RepeleX, RepeleY);                
            }
            

            else if(GetComponent<SpriteRenderer>().flipX == true)
            {
                rb.velocity = new Vector2(RepeleX, RepeleY);               
                
            }

            GameManager.instance.TakeDamage(repelDamage);
                
        }
    }

    public void CanClimb(bool can)
    {
        canClimb = can;
    }

}
