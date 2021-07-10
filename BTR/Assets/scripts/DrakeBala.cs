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
        boss = GameObject.FindWithTag("FinalBoss").GetComponent<Transform>();
	}
	
	
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.tag == "Player")
        {
            // TRACKER EVENT
            string[] param = { collision.transform.position.x.ToString(), collision.transform.position.y.ToString() };
            GameManager.instance_Tracker.addTrackerEvent(TrackerSpace.Tracker.EventType.PLAYER_HIT, param);

            string[] arg = { "DRAKE" };
            GameManager.instance_Tracker.addTrackerEvent(TrackerSpace.Tracker.EventType.ENEMY_MAKES_DAMAGE, arg);

            GameManager.instance.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Bala")
            Destroy(gameObject);
        else if(collision.gameObject.tag == "BulletDestroyer")
        {
            Destroy(gameObject);
        }
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
