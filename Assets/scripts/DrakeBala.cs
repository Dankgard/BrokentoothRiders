using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrakeBala : MonoBehaviour {

    public float vidaBala;
    Transform player;
    public int bulletDamage;
    Rigidbody2D missileRB;
    public float speed;
    Transform boss;

    public int bulletAngle = 40;


	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Destroy(gameObject, vidaBala);
        missileRB = GetComponent<Rigidbody2D>();
        boss = GameObject.FindWithTag("Boss").GetComponent<Transform>();
	}
	
	
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Bala")
            Destroy(gameObject);
    }

    public void InvertSpeed()
    {
        int velY = Random.Range(-5, 5);

        if (player.localPosition.x < transform.localPosition.x)
        {
            missileRB.velocity = new Vector2(speed, velY);
            float angle = Mathf.Atan2(velY, -speed / 4) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            missileRB.velocity = new Vector2(-speed, velY);
            float angle = Mathf.Atan2(velY, speed / 4) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            GetComponent<SpriteRenderer>().flipY = false;
        }
    }

    void Update()
    {
        transform.RotateAround(boss.position, Vector3.forward, bulletAngle * Time.deltaTime);
    }
}
