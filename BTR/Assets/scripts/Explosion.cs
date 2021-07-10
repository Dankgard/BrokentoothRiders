using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public int explosionDamage;
    public int destroyTime;
    public float colliderDestroyTime;

    public AudioClip explosionSound;
    BoxCollider2D collider;
    public string enemy;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        SoundManager.instance.PlaySound(explosionSound, 0.4f);
        Destroy(collider, colliderDestroyTime);
        Destroy(gameObject, destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // TRACKER EVENT
            string[] param = { collision.transform.position.x.ToString(), collision.transform.position.y.ToString() };
            GameManager.instance_Tracker.addTrackerEvent(TrackerSpace.Tracker.EventType.PLAYER_HIT, param);

            string[] arg = { enemy };
            GameManager.instance_Tracker.addTrackerEvent(TrackerSpace.Tracker.EventType.ENEMY_MAKES_DAMAGE, arg);

            GameManager.instance.TakeDamage(explosionDamage);
        }
        if(collision.gameObject.tag == "Enemigo")
        {
            VidaEnemigo enemigo = collision.gameObject.GetComponent<VidaEnemigo>();
            enemigo.TakeDamage(explosionDamage);
        }
        if (collision.gameObject.tag == "Caja" || collision.gameObject.tag == "NPC")
        {
            Destroy(collision.gameObject);
        }
    }
}
