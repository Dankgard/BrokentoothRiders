using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrakeDisparo : MonoBehaviour {

    public bool playerInRange = false;
    DrakeMovimiento mov;
    GameObject player;

    public DrakeBala proyectil;

    public float throwTime;
    float throwCount;

    public float bulletTime;

    public int bulletWaves;
    int bulletWav;
    bool cruz = true;

    public float bulletSpeed;

	void Awake () {
        player = GameObject.FindWithTag("Player");
        mov = GetComponent<DrakeMovimiento>();
        bulletWav = bulletWaves;
	}
	
	void Update () {
        throwCount += Time.deltaTime;
        if (throwCount >= throwTime && !mov.colisionPlayer)
        {
            DisparoCircular();
            throwCount = 0;
        }
	}

    void DisparoCircular()
    {
            if (cruz)
            {
                DrakeBala bala1 = Instantiate(proyectil, transform.position, Quaternion.identity);
                bala1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
                DrakeBala bala2 = Instantiate(proyectil, transform.position, Quaternion.identity);
                bala2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
                DrakeBala bala3 = Instantiate(proyectil, transform.position, Quaternion.identity);
                bala3.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
                DrakeBala bala4 = Instantiate(proyectil, transform.position, Quaternion.identity);
                bala4.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, 0);
                cruz = false;
            }
            else
            {
                DrakeBala bala1 = Instantiate(proyectil, transform.position, Quaternion.identity);
                bala1.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, bulletSpeed);
                DrakeBala bala2 = Instantiate(proyectil, transform.position, Quaternion.identity);
                bala2.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, -bulletSpeed);
                DrakeBala bala3 = Instantiate(proyectil, transform.position, Quaternion.identity);
                bala3.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, bulletSpeed);
                DrakeBala bala4 = Instantiate(proyectil, transform.position, Quaternion.identity);
                bala4.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletSpeed, -bulletSpeed);
                cruz = true;
            }
            bulletWav--;
            if(bulletWav>0)
            {
                Invoke("DisparoCircular", bulletTime);
            }
            else
            {
                bulletWav = bulletWaves;
            }
        }
    }

