using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Tracker;

public class Bala : MonoBehaviour {

    public int bulletDamage;

    public GameObject[] blood = new GameObject[7];
    
    int bloodType;
    public float bloodTime;

    public AudioClip[] bloodSound = new AudioClip[13];
    int bloodSoundType;

    bool destroyedByColision = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Suelo")
        {
            string nombre;
            if (GameObject.FindWithTag("Player").GetComponent<DisparoRex>().automaticWeapon)
                nombre = "Rifle";
            else
                nombre = "Shotgun";

            string[] arg = { nombre, "false" };

            GameManager.instance_Tracker.RegisterEvent(BTR_Tracker.EventType.WEAPON_ACCURACY, arg);

            destroyedByColision = true;

            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "EnemyBullet" || collider.gameObject.tag == "Proyectil")
        {
            string nombre;
            if (GameObject.FindWithTag("Player").GetComponent<DisparoRex>().automaticWeapon)
                nombre = "Rifle";
            else
                nombre = "Shotgun";

            string[] arg = { nombre, "true" };

            GameManager.instance_Tracker.RegisterEvent(BTR_Tracker.EventType.WEAPON_ACCURACY, arg);

            destroyedByColision = true;

            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "Enemigo" || collider.gameObject.tag == "Boss")
        {
            /*// TRACKER EVENT
            var prefabGameObject = PrefabUtility.GetPrefabParent(collider.gameObject);
            string[] parameters = { prefabGameObject.name };
            GameManager.instance_Tracker.RegisterEvent(Tracker.BTR_Tracker.EventType.HIT_FREQUENCY, parameters);*/
            
            VidaEnemigo enemigo = collider.gameObject.GetComponent<VidaEnemigo>();
            enemigo.TakeDamage(bulletDamage);
            Bleed();
            string nombre;
            if (GameObject.FindWithTag("Player").GetComponent<DisparoRex>().automaticWeapon)
                nombre = "Rifle";
            else
                nombre = "Shotgun";

            string[] arg = { nombre , "true"};

            GameManager.instance_Tracker.RegisterEvent(BTR_Tracker.EventType.WEAPON_ACCURACY, arg);

            destroyedByColision = true;

            Destroy(gameObject);

        }
        else if(collider.gameObject.tag == "FinalBoss")
        {
            DrakeVida boss = collider.gameObject.GetComponent<DrakeVida>();
            boss.TakeDamage(bulletDamage);
            Bleed();

            string nombre;
            if (GameObject.FindWithTag("Player").GetComponent<DisparoRex>().automaticWeapon)
                nombre = "Rifle";
            else
                nombre = "Shotgun";

            string[] arg = { nombre, "true" };

            GameManager.instance_Tracker.RegisterEvent(BTR_Tracker.EventType.WEAPON_ACCURACY, arg);

            destroyedByColision = true;

            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "Caja")
        {
            Caja caja = collider.GetComponent<Caja>();
            caja.TakeDamage(bulletDamage);

            string nombre;
            if (GameObject.FindWithTag("Player").GetComponent<DisparoRex>().automaticWeapon)
                nombre = "Rifle";
            else
                nombre = "Shotgun";

            string[] arg = { nombre, "true" };

            GameManager.instance_Tracker.RegisterEvent(BTR_Tracker.EventType.WEAPON_ACCURACY, arg);

            destroyedByColision = true;

            Destroy(gameObject);
        }
        else if(collider.gameObject.tag == "NPC")
        {
            Bleed();

            string nombre;
            if (GameObject.FindWithTag("Player").GetComponent<DisparoRex>().automaticWeapon)
                nombre = "Rifle";
            else
                nombre = "Shotgun";

            string[] arg = { nombre, "true" };

            GameManager.instance_Tracker.RegisterEvent(BTR_Tracker.EventType.WEAPON_ACCURACY, arg);

            destroyedByColision = true;

            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }

    void Bleed()
    {
        bloodSoundType = Random.Range(0, 13);
        SoundManager.instance.PlaySound(bloodSound[bloodSoundType],1.0f);
     
        bloodType = Random.Range(0, 7);
        GameObject sangre = Instantiate(blood[bloodType], transform.position, Quaternion.identity);
        Destroy(sangre, bloodTime);
    }

    void OnDestroy()
    {
        if (!destroyedByColision)
        {
            string nombre;
            if (GameObject.FindWithTag("Player").GetComponent<DisparoRex>().automaticWeapon)
                nombre = "Rifle";
            else
                nombre = "Shotgun";

            string[] arg = { nombre, "false" };

            GameManager.instance_Tracker.RegisterEvent(BTR_Tracker.EventType.WEAPON_ACCURACY, arg);
        }
    }
}
