using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoHelicoptero : MonoBehaviour {

    public bool playerInRange = false;
    public GameObject misilePrefab;
    public GameObject missileSpawner;
    public GameObject player;
    public Transform enemyTrans;

    public MovimientoHelicoptero mov;

    public float shootingRate;
    float shootingCount;
    // Use this for initialization
    void Start()
    {
        shootingCount = shootingRate;
        mov = GetComponentInParent<MovimientoHelicoptero>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {            
            shootingCount += Time.deltaTime;
            if (shootingCount >= shootingRate && !mov.colisionPlayer)
            {
                Instantiate(misilePrefab, missileSpawner.transform.position, misilePrefab.transform.rotation);
                shootingCount = 0;
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
