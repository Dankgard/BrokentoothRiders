using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoTorreta : MonoBehaviour {

    Vector3 direccionBala;
    public Transform jugador;
    public GameObject bala;
    public Transform SpawnBala;
    public float speed;
    public float alcance;
    bool disparo = true;
    public float delay;
    bool playerInRange = false;

    public AudioClip shootSound;

	// Use this for initialization
	void Start () {
        jugador = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (disparo && playerInRange)
        {
            Disparo();
            SoundManager.instance.PlaySound(shootSound, 0.25f);
            Invoke("NewBullet", delay);
        }
	}

    void Disparo()
    {
        direccionBala = jugador.position;
        direccionBala.z = 0f;
        direccionBala = direccionBala - SpawnBala.position;

        GameObject bullet = Instantiate(bala, SpawnBala.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        Vector2 dir = direccionBala.normalized;

        bullet.GetComponent<Rigidbody2D>().velocity = dir * speed;
        Destroy(bullet, alcance);
        disparo = false;
    }
    private void NewBullet()
    {
        disparo = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
