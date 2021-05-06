using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Cursor : MonoBehaviour
{
    public SpriteRenderer cursor;
    public Sprite[] color;
    void Start()
    {
        cursor = GetComponentInChildren<SpriteRenderer>();
        UnityEngine.Cursor.visible = false;
        cursor.sprite = color[0];
    }
    void FixedUpdate()
    {
        Vector3 CursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(CursorPos.x, CursorPos.y,transform.position.z);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemigo"))
        {
            cursor.sprite = color[1];
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Enemigo"))
        {
            cursor.sprite = color[0];
        }
    }
}
