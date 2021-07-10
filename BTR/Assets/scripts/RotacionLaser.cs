using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionLaser : MonoBehaviour {

    public Transform laser;
    public float speed;
    public float degrees;
    bool direccion;
    public int daño;
	// Use this for initialization
	void Start () {
        direccion = true;
	}
	
	// Update is called once per frame
	void Update () {

        degrees = degrees + (speed / 10);
        laser.localRotation = Quaternion.Euler(0f, 0f, degrees);               
                        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DireccLaser")
        {            
            speed = -speed;
        }

        else if (collision.gameObject.tag == "Player")
        {
            string[] arg = { "LASER" };
            GameManager.instance_Tracker.addTrackerEvent(TrackerSpace.Tracker.EventType.ENEMY_MAKES_DAMAGE, arg);

            string[] param = { collision.transform.position.x.ToString(), collision.transform.position.y.ToString() };
            GameManager.instance_Tracker.addTrackerEvent(TrackerSpace.Tracker.EventType.PLAYER_HIT, param);

            GameManager.instance.TakeDamage(daño);            
        }
    }
}
