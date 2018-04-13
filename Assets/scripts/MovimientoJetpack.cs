using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJetpack : MonoBehaviour
{    
    public float speedY;      
    public Transform topeAbajo;
    public Transform topeArriba;
    public int probCambioSentido;

    void Update()
    {      
        if (transform.position.y <= topeAbajo.position.y || transform.position.y >= topeArriba.position.y)
        {
            speedY = -speedY;
        }
        transform.Translate(0, speedY * Time.deltaTime, 0);  //el movimiento sea posible 

    }

    void FixedUpdate()
    {        
        if (Random.Range(0, probCambioSentido) == 0)
        {
            speedY = -speedY;
        }
    }
}