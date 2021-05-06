using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour {

    public GameObject PaqueteVida;
    public GameObject PaqueteEnergia;
    public GameObject PaqueteEscopeta;
    public GameObject PaqueteRifle;


    int select;
    GameObject paquete;

    public int initialHealth;
    int health;

    void Awake()
    {
        select = Random.Range(1, 5);

        if (select == 1)
            paquete = PaqueteEnergia;
        else if (select == 2)
            paquete = PaqueteVida;
        else if (select == 3)
            paquete = PaqueteEscopeta;
        else if (select == 4)
            paquete = PaqueteRifle;

        health = initialHealth;
    }


    public void TakeDamage(int bulletDamage)
    {
        health -= bulletDamage;
    }


    private void Update()
    {
        if (health <= 0)
        {
            GameObject drop = Instantiate(paquete, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
    }


}
