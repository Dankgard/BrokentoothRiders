using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaTorreta : MonoBehaviour {
    public int bulletDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.gameObject.tag == "Suelo")
            Destroy(gameObject);
        else if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Bala")
            Destroy(gameObject);
    }
}
