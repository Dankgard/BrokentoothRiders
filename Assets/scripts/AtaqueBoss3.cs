using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueBoss3 : MonoBehaviour {

    public bool playerInRange = false;
    public MovimientoBoss3 mov;
    GameObject player;

    public GameObject proyectil;

    public float throwTime;
    float throwCount;

    public GameObject enemyTrans;

    public int maxShurikens;

    public AudioClip attackSound;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (playerInRange)
        {
            throwCount += Time.deltaTime;
            if (throwCount >= throwTime && !mov.colisionPlayer)
            {

                for(int i=0;i<maxShurikens;i++)
                {
                    GameObject proyectile = Instantiate(proyectil, enemyTrans.transform.position, Quaternion.identity);
                    Rigidbody2D rb = proyectile.GetComponent<Rigidbody2D>();
                    rb.velocity = new Vector2(Random.Range(0,10), Random.Range(0, 10));
                }
                SoundManager.instance.PlaySound(attackSound, 0.5f);
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
