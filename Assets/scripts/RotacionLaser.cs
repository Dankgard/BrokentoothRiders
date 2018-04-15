using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionLaser : MonoBehaviour {

    public Transform laser;
    public float speed;
    public float degrees;
    bool direccion;
	// Use this for initialization
	void Start () {
        direccion = true;
	}
	
	// Update is called once per frame
	void Update () {
        
        laser.localRotation = Quaternion.Euler(0f, 0f, degrees);
                        

        if (direccion)
        {
            degrees++;
        }
        else
            degrees--;


        if (degrees >= 18)
        {
            direccion = false;
        }
        else if (degrees <= -95)
        {
            direccion = true;
        }
    }
}
//18 0 -95