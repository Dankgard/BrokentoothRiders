
using UnityEngine;

public class Granada : MonoBehaviour {

    public Explosion explosion;
    public string enemy;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Suelo" || other.gameObject.tag == "Enemigo")
        {
            explosion.enemy = enemy;
            Explosion boom = Instantiate(explosion, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
    }
}
