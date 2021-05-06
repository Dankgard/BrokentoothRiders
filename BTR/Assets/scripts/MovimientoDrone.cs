using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDrone : MonoBehaviour {

    public float speedX;
    public float speedY;
    public Transform topeIzquierda;
    public Transform topeDerecha;
    public Transform topeAbajo;
    public Transform topeArriba;
    public int probCambioSentido;

    void Update()
    {
        if (transform.position.x <= topeIzquierda.position.x || transform.position.x >=topeDerecha.position.x)
        { //para que la nave no se salga de los topes laterales que indiques 
            speedX = -speedX;
        }

        if(transform.position.y<=topeAbajo.position.y || transform.position.y >= topeArriba.position.y)
        {
            speedY = -speedY;
        }
        transform.Translate(speedX*Time.deltaTime, speedY*Time.deltaTime, 0);  //el movimiento sea posible 

    }

    void FixedUpdate()
    {
        if (Random.Range(0, probCambioSentido) == 0)
        {// un probabilidad entre 0 y el valor que le des (int) y si es 0 cambia de sentido
            speedX = -speedX;
        }
        if (Random.Range(0, probCambioSentido) == 0)
        {
            speedY = -speedY;
        }
    }
}
