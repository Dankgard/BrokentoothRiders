using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoBoss1 : MonoBehaviour {

    public bool playerInRange = false;
    public GameObject misilePrefab;
    public GameObject missileSpawner;
    GameObject player;
    public Transform enemyTrans;

    public MovimientoBoss1 mov;

    public float shootingRate;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (playerInRange)
        {

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

    void Shoot()
    {
        Instantiate(misilePrefab, missileSpawner.transform.position, misilePrefab.transform.rotation);
    }
}
