using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundtest : MonoBehaviour {

    public AudioClip c;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            AudioSource s = gameObject.GetComponent<AudioSource>();
            s.PlayOneShot(c,1.0f);
        }
	}
}
