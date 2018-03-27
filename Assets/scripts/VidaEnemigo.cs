using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VidaEnemigo : MonoBehaviour {

    public float vidaInicial;
    float vida;

    public bool isBoss = false;
    public string escena;

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

            if(isBoss)
                SceneManager.LoadScene(escena);
        }
    }

    public void TakeDamage(int damage)
    {
        vida -= damage;
    }
}
