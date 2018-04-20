using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrakeVida : MonoBehaviour {

    public float vidaInicial;
    float vida;
    float vidaFase;

    public bool isBoss = false;
    public string escena;
    bool cargando = false;

    public int fase = 1;

    private void Awake()
    {
        vida = vidaInicial;
        vidaFase = vidaInicial / 3;
    }
    // Update is called once per frame
    void Update()
    {
        if(vida<=1000 && fase == 1)
        {
            fase = 2;
        }
        else if (vida<=500 && fase == 2)
        {
            fase = 3;
        }

        if (vida <= 0)
        {
            if (isBoss)
                GameManager.instance.StartLoadingScene(escena);
            Destroy(transform.parent.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        vida -= damage;
    }
}
