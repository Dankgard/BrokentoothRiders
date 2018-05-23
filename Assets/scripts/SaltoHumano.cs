using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoHumano : MonoBehaviour
{

    int NSaltos = 2;
    public int Fuerza;
    Rigidbody2D rb;    
    bool salto = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();       
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo1")
        {
            salto = true;
        }
    }

    public void Update()
    {
        if (rb.velocity.y == 0 || salto)
        {
            NSaltos = 2;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (NSaltos > 0)
            {
                rb.velocity = new Vector2(0, Fuerza);
                NSaltos -= 1;
            }
        }
        salto = false;

    }

}
