using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEspMut : MonoBehaviour
{

    public bool playerInRange = false;
    public MovimientoEspMut mov;
    GameObject player;

    public GameObject proyectil;

    public float throwTime;
    float throwCount;

    public GameObject enemyTrans;

    float force;

    public AudioClip attackSound;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(playerInRange)
        {
            throwCount += Time.deltaTime;
            if (throwCount >= throwTime && !mov.colisionPlayer)
            {
                GameObject proyectile = Instantiate(proyectil, enemyTrans.transform.position, Quaternion.identity);
                Rigidbody2D rb = proyectile.GetComponent<Rigidbody2D>();
                force = Random.Range(4, 10);
                if (player.transform.position.x <= transform.position.x)
                {
                    rb.velocity = new Vector2(-force, force);
                }
                else if (player.transform.position.x >= transform.position.x)
                {
                    rb.velocity = new Vector2(force, force);
                }
                SoundManager.instance.PlaySound(attackSound, 0.25f);
                throwCount = 0;
            }
        }
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
