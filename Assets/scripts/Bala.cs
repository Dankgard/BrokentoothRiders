using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    public int bulletDamage;

    public GameObject blood1;
    public GameObject blood2;
    public GameObject blood3;
    public GameObject blood4;
    public GameObject blood5;
    public GameObject blood6;
    public GameObject blood7;
    GameObject blood;

    int bloodType;
    public float bloodTime;


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Suelo" || collider.gameObject.tag == "EnemyBullet" || collider.gameObject.tag == "Proyectil")
            Destroy(gameObject);
        else if (collider.gameObject.tag == "Enemigo" || collider.gameObject.tag == "Boss")
        {
            VidaEnemigo enemigo = collider.gameObject.GetComponent<VidaEnemigo>();
            enemigo.TakeDamage(bulletDamage);
            Bleed();
            Destroy(gameObject);

        }
        else if(collider.gameObject.tag == "FinalBoss")
        {
            DrakeVida boss = collider.gameObject.GetComponent<DrakeVida>();
            boss.TakeDamage(bulletDamage);
            Bleed();
            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "Caja")
        {
            Caja caja = collider.GetComponent<Caja>();
            caja.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else if(collider.gameObject.tag == "NPC")
        {
            Bleed();
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }

    void Bleed()
    {
        bloodType = Random.Range(1, 8);
        switch(bloodType)
        {
            case 1:
                blood = blood1;
                break;
            case 2:
                blood = blood2;
                break;
            case 3:
                blood = blood3;
                break;
            case 4:
                blood = blood4;
                break;
            case 5:
                blood = blood5;
                break;
            case 6:
                blood = blood6;
                break;
            case 7:
                blood = blood7;
                break;
        }

        GameObject sangre = Instantiate(blood, transform.position, Quaternion.identity);
        Destroy(sangre, bloodTime);
    }
}
