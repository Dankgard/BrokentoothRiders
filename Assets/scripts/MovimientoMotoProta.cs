using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMotoProta : MonoBehaviour {

    public float speed = 10;
    public float fuerza;
    public float tiempoaumneto = 1; //tiempo entre aumnetos de velocidad
    Rigidbody2D rb;
    public int NSaltos = 1;
    bool aumentar = true;
    bool veloc = true;
    
	void Start () {
        rb = GetComponent<Rigidbody2D>();        
	}

    void FixedUpdate()
    {               

        if (aumentar)
        {
            aumentar = false;
            Invoke("AumentarVelocidad", tiempoaumneto);
        }
    }

    // Update is called once per frame
    void Update () {

        if (rb.velocity.y == 0)
            NSaltos = 1;

        if (Input.GetButtonDown("Jump") && veloc)
        {
            if (NSaltos > 0)
            {                
                Vector2 s = new Vector2(rb.velocity.x, fuerza);
                rb.velocity = s;
                NSaltos -= 1;                
            }
        }
        else if (veloc)
        {            
            Vector2 v = new Vector2(speed, rb.velocity.y);
            rb.velocity = v;            
        }

        if (rb.velocity.x == 0)
        {
            veloc = false;
            Destroy(gameObject);          

        }
        
    }
    
    void AumentarVelocidad()
    {
        speed = speed + 1;
        aumentar = true;
    }
    

}
