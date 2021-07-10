using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaTorreta : MonoBehaviour {
    public int bulletDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.gameObject.tag == "Suelo")
            Destroy(gameObject);
        else if (collision.gameObject.tag == "Player")
        {
            // TRACKER EVENT
            string[] param = { collision.transform.position.x.ToString(), collision.transform.position.y.ToString() };
            GameManager.instance_Tracker.addTrackerEvent(TrackerSpace.Tracker.EventType.PLAYER_HIT, param);

            string[] arg = { "TORRETA" };
            GameManager.instance_Tracker.addTrackerEvent(TrackerSpace.Tracker.EventType.ENEMY_MAKES_DAMAGE, arg);

            GameManager.instance.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Bala")
            Destroy(gameObject);
    }
}
