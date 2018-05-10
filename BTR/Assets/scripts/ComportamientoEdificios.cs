﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoEdificios : MonoBehaviour {
    public GameObject endPoint;    
    public float caida;
    public bool start = false;
    public GameObject humos;
	// Use this for initialization
	void Start () {
        humos.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (start)
        {
            humos.SetActive(true);
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, endPoint.transform.position.y), caida * Time.deltaTime);
        }            
       
    }
}
