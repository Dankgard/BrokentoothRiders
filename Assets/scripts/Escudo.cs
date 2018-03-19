using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour {

	public int shieldLength;
    Transform player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Destroy(gameObject, shieldLength);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            BalaEnemiga bala = collision.GetComponent<BalaEnemiga>();
            bala.InvertSpeed();
        }
    }

    private void Update()
    {
        if(GameManager.instance.Alive())
            transform.position = player.position;
    }


}
