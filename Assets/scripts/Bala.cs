using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    public int bulletDamage;

    public GameObject[] blood = new GameObject[7];
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

    AudioSource source;
    public AudioClip bl1;
    public AudioClip bl2;
    public AudioClip bl3;
    public AudioClip bl4;
    public AudioClip bl5;
    public AudioClip bl6;
    public AudioClip bl7;
    public AudioClip bl8;
    public AudioClip bl9;
    public AudioClip bl10;
    public AudioClip bl11;
    public AudioClip bl12;
    public AudioClip bl13;
    AudioClip bloodSound;
    int bloodSoundType;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }


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
        bloodSoundType = Random.Range(1, 14);

        switch (bloodSoundType)
        {
            case 1:
                bloodSound = bl1;
                break;
            case 2:
                bloodSound = bl2;
                break;
            case 3:
                bloodSound = bl3;
                break;
            case 4:
                bloodSound = bl4;
                break;
            case 5:
                bloodSound = bl5;
                break;
            case 6:
                bloodSound = bl6;
                break;
            case 7:
                bloodSound = bl7;
                break;
            case 8:
                bloodSound = bl8;
                break;
            case 9:
                bloodSound = bl9;
                break;
            case 10:
                bloodSound = bl10;
                break;
            case 11:
                bloodSound = bl11;
                break;
            case 12:
                bloodSound = bl12;
                break;
            case 13:
                bloodSound = bl13;
                break;
        }
        source.PlayOneShot(bl1,1.0f);//bloodSound,1.0f);

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
