using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour {

    RectTransform trans;
    public RectTransform thanks;

	// Use this for initialization
	void Start () {
        trans = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        if(thanks.transform.position.y<250)
            trans.transform.position = new Vector2(trans.transform.position.x, trans.transform.position.y + 1);
	}
}
