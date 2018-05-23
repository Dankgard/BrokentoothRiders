using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aplastamiento : MonoBehaviour {   

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    public GameObject jugador;	
=======
    
>>>>>>> parent of 3dc7854... Arreglando algunos errores de salto y de nivel
=======
    
>>>>>>> parent of 3dc7854... Arreglando algunos errores de salto y de nivel
=======
    public bool edificio = false;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            edificio = true;
            Debug.Log("funciona");
        }
    }
>>>>>>> parent of d176b78... Revert "Merge remote-tracking branch 'origin/Gonzalo-Alejandro'"

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Aplastamiento")
        {
            Debug.Log("Muerte");
            GameManager.instance.Death();
        }
        
    }   

}
