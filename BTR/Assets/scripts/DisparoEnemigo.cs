using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour {

    public bool playerInRange = false;
    public GameObject misilePrefab;
    public GameObject missileSpawner;
    public GameObject player;
    public Transform enemyTrans;

    public MovimientoEnemigos mov;

    public float shootingRate;
    float shootingCount;

    public AudioClip shootSound;

	// Use this for initialization
	void Start () {
        shootingCount = shootingRate;
        mov = GetComponentInParent<MovimientoEnemigos>();
        player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (playerInRange)
        {
            if(player.transform.position.x<= enemyTrans.transform.position.x)
            {                
                enemyTrans.transform.localScale = new Vector3(1, 1, 1);
            }
            else if(player.transform.position.x >= enemyTrans.transform.position.x)
            {                
                enemyTrans.transform.localScale = new Vector3(-1, 1, 1);
            }
            shootingCount += Time.deltaTime;
            if (shootingCount >= shootingRate && !mov.colisionPlayer)
            {
                Instantiate(misilePrefab, missileSpawner.transform.position, misilePrefab.transform.rotation);
                SoundManager.instance.PlaySound(shootSound, 0.25f);
                shootingCount = 0;
            }
        }
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag== "Player")
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
