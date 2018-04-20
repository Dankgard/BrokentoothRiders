using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour {

    public int repulsionSpeed;
	public int shieldLength;
    Transform player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Destroy(gameObject, shieldLength);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Proyectil" || collision.gameObject.tag == "EnemyBullet")
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            int velY = Random.Range(-5, 5);

            if (player.localPosition.x < collision.transform.localPosition.x)
            {
                rb.velocity = new Vector2(repulsionSpeed, velY);
                float angle = Mathf.Atan2(velY, -repulsionSpeed / 4) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                GetComponent<SpriteRenderer>().flipY = true;
            }
            else
            {
                rb.velocity = new Vector2(-repulsionSpeed, velY);
                float angle = Mathf.Atan2(velY, repulsionSpeed / 4) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                GetComponent<SpriteRenderer>().flipY = false;
            }
        }
    }

    private void Update()
    {
        if(GameManager.instance.Alive())
            transform.position = player.position;
    }


}
