using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanRock : MonoBehaviour {

    public int damage;

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.instance.TakeDamage(damage);
            Destroy(gameObject);
        }

        else if(other.gameObject.tag == "Suelo")
        {
            Destroy(gameObject);
        }
    }
}
