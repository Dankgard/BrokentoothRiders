using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrakeMovimiento : MonoBehaviour {

    GameObject player;
    public bool colisionPlayer = false;

    public float teleportTime;
    float throwCount;

    public GameObject teleporter;
    public float teleportDestroyTime;

    public bool teleport = true;

    public AudioClip teleportSound;

    void Start () {
        player = GameObject.FindWithTag("Player");
	}
	
	void Update () {
        if (teleport)
        {
            throwCount += Time.deltaTime;
            if (throwCount >= teleportTime)
            {
                Teleport();
                SoundManager.instance.PlaySound(teleportSound, 1.0f);
                throwCount = 0;
            }
        }

        if (player.transform.position.x <= transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
        else if (player.transform.position.x >= transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void Teleport()
    {
        GameObject tp = Instantiate(teleporter, transform.position - new Vector3(0,0.5f,0), Quaternion.identity);
        Destroy(tp, teleportDestroyTime);
        Transform spawnPoint;
        int spawn = Random.Range(1, 9);
        spawnPoint = transform.parent.GetChild(1).GetChild(spawn);
        transform.position = new Vector2(spawnPoint.position.x, spawnPoint.position.y);       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!colisionPlayer)
            {
                string[] arg = { gameObject.GetComponent<DrakeVida>().name };
                GameManager.instance_Tracker.RegisterEvent(Tracker.BTR_Tracker.EventType.HIT_FREQUENCY, arg);
            }
            colisionPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            colisionPlayer = false;
        }
    }
}
