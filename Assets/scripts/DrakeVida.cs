using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrakeVida : MonoBehaviour {

    public int vidaInicial;
    public int vida;
    int vidaFase2;
    int vidaFase3;

    public bool isBoss = false;
    public string escena;
    bool cargando = false;

    public int fase = 1;

    private void Awake()
    {
        vida = vidaInicial;
        vidaFase2 = vidaInicial / 3 * 2;
        vidaFase3 = vidaInicial / 3;
    }

    void Update()
    {
        if(vida<=vidaFase2 && fase == 1)
        {
            fase = 2;
            SpawnTurrets();
        }
        else if (vida<=vidaFase3 && fase == 2)
        {
            fase = 3;
            SpawnLasers();
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

    void SpawnTurrets()
    {
        transform.parent.GetChild(2).gameObject.SetActive(true);
    }

    void SpawnLasers()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
