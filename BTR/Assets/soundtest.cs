using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Tracker;

public class soundtest : MonoBehaviour {

    //public AudioClip c;
    // Use this for initialization

    DamageFrequency d = new DamageFrequency();
    void Start () {
        d.AddPosition(1, 1);
        //d.ToJson();
        string json = JsonUtility.ToJson(d);
        d = JsonUtility.FromJson<DamageFrequency>(json);
        File.WriteAllText("Files/DamageFrequency.json", json);
        /*string jsonFile = JsonConvert.SerializeObject(d, Formatting.Indented);
        File.WriteAllText("../Files/DamageFrequency.json", jsonFile);*/
    }
	
	// Update is called once per frame
	void Update () {
        /*if (Input.anyKeyDown)
        {
            AudioSource s = gameObject.GetComponent<AudioSource>();
            s.PlayOneShot(c,1.0f);
        }*/
	}
}
