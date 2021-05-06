using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoHumano : MonoBehaviour
{

    int NSaltos = 2;
    public int Fuerza;
    public GameObject jugador;
   // public Rigidbody2D rb;    
    

    void Start()
    {
       // rb = GetComponent<Rigidbody2D>();       
    }
    /*public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo1")
        {
            salto = true;
        }
    }*/
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Suelo" || collision.gameObject.tag == "Suelo1" || collision.gameObject.tag =="Caja")
        {
            NSaltos = 2;
        }
    }

    public void Update()
    {
       /* if (rb.velocity.y == 0)
        {
            NSaltos = 2;
        }*/

        if (Input.GetButtonDown("Jump"))
        {
            if (NSaltos > 0)
            {
                jugador.GetComponent<Rigidbody2D>().velocity= new Vector2(0, Fuerza);
                NSaltos -= 1;
            }
        }        

    }

}
