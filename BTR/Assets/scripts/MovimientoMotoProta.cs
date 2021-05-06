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
    public GameObject humo;
    
    
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        humo.active = true;        
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

        /*if (rb.velocity.x <= speed)
        {
            veloc = false;
            Destroy(gameObject);

        }*/

        if (rb.velocity.y == 0)
        {
            NSaltos = 1;
            humo.active = true;
        }
        else humo.active = false;
            

        if (Input.GetButtonDown("Jump") && rb.velocity.y==0)
        {
            

            if (NSaltos > 0)
            {                
                Vector2 s = new Vector2(rb.velocity.x, fuerza);                
                rb.velocity = s;
                NSaltos -= 1;                
            }
        }
        else
        {            
            Vector2 v = new Vector2(speed, rb.velocity.y);
            rb.velocity = v;            
        }        
        
    }
    
    void AumentarVelocidad()
    {
        speed = speed + 1;
        aumentar = true;
    }
    

}
