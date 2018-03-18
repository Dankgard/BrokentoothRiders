using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour {

    public float vidaInicial;
    float vida;

    private void Awake()
    {
        vida = vidaInicial;
    }
    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        vida -= damage;
    }
}
