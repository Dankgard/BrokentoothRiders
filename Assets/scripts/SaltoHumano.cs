using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoHumano : MonoBehaviour
{

    int NSaltos = 2;
    public int Fuerza;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (rb.velocity.y == 0)
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

    }

}
