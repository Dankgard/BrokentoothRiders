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
        if (direccion)
        {
            laser.localRotation = Quaternion.Euler(0f, 0f, degrees);
        }
        else
            laser.localRotation = Quaternion.Euler(0f, 0f, -degrees);

        degrees++;
        if (degrees >= 8)
        {
            degrees--;
        }
	}
}
//-100 0 55