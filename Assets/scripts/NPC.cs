using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public TextDialog textDialog;
    public string text;

    Vector3 textOffset;

	// Use this for initialization
	void Start () {
        text = text.Replace("\\n", "\n");
        textOffset = new Vector3(0, 4, 0);
	}
	
	

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                TextDialog dialog = Instantiate(textDialog, transform.position + textOffset, Quaternion.identity);
                TextMesh texto = dialog.GetComponentInChildren<TextMesh>();
                texto.text = text;
            }
        }
    }
}
