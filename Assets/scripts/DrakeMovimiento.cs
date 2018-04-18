using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrakeMovimiento : MonoBehaviour {

    public int time;

    GameObject player;

    public float throwTime;
    float throwCount;

	void Start () {
        player = GameObject.FindWithTag("Player");
	}
	
	void Update () {
        throwCount += Time.deltaTime;
        if (throwCount >= throwTime)
        {
            if (player.transform.position.x <= transform.position.x)
            {

            }
            else if (player.transform.position.x >= transform.position.x)
            {
            }
            throwCount = 0;
        }
		
	}
}
