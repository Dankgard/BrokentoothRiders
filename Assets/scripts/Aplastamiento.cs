using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aplastamiento : MonoBehaviour {   

<<<<<<< HEAD
<<<<<<< HEAD
    public GameObject jugador;	
=======
    
>>>>>>> parent of 3dc7854... Arreglando algunos errores de salto y de nivel
=======
    
>>>>>>> parent of 3dc7854... Arreglando algunos errores de salto y de nivel

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Aplastamiento")
        {
            Debug.Log("Muerte");
            GameManager.instance.Death();
        }
    }   

}
