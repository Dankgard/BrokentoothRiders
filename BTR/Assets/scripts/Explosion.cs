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
            GameManager.instance.TakeDamage(explosionDamage);
            Debug.Log("Tracker: Grenade hurt player");
            GameManager.instance_Tracker.RegisterEvent(Tracker.Practica_Final_Tracker.EventType.GRENADE_HURTS_PLAYER);
        }
        if(collision.gameObject.tag == "Enemigo")
        {
            VidaEnemigo enemigo = collision.gameObject.GetComponent<VidaEnemigo>();
            enemigo.TakeDamage(explosionDamage);
            Debug.Log("Tracker: Grenade hurt enemy");
            GameManager.instance_Tracker.RegisterEvent(Tracker.Practica_Final_Tracker.EventType.GRENADE_HURTS_ENEMY);
        }
        if (collision.gameObject.tag == "Caja" || collision.gameObject.tag == "NPC")
        {
            Destroy(collision.gameObject);
        }
    }
}
