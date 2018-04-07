using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    public int bulletDamage;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Suelo")
            Destroy(gameObject);
        else if (collider.gameObject.tag == "Enemigo")
        {
            VidaEnemigo enemigo = collider.gameObject.GetComponent<VidaEnemigo>();
            enemigo.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "EnemyBullet")
            Destroy(gameObject);
        else if(collider.gameObject.tag == "Proyectil")
            Destroy(gameObject);
        else if (collider.gameObject.tag == "Caja")
        {
            Caja caja = collider.GetComponent<Caja>();
            caja.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else if(collider.gameObject.tag == "NPC")
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }

    }
}
