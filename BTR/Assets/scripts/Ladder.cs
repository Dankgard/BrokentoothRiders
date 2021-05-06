using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    MovimientoProtagonista mov;

    private void Awake()
    {
        mov = GameObject.FindWithTag("Player").GetComponent<MovimientoProtagonista>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mov.CanClimb(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mov.CanClimb(false);

        }
    }
}
    
