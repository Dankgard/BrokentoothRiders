using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public int explosionDamage;
    public int destroyTime;

    private void Awake()
    {
        Destroy(gameObject, destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            GameManager.instance.TakeDamage(explosionDamage);
        if(collision.gameObject.tag == "Enemigo")
        {
            VidaEnemigo enemigo = collision.gameObject.GetComponent<VidaEnemigo>();
            enemigo.TakeDamage(explosionDamage);
        }
        if (collision.gameObject.tag == "Caja")
        {
            Destroy(collision.gameObject);
        }
    }
}
