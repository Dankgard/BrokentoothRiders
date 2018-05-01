using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrakeVida : MonoBehaviour {

    public int vidaInicial;
    public int vida;
    int vidaFase2;
    int vidaFase3;

    public bool isBoss = false;
    public string escena;
    bool cargando = false;

    public int fase = 1;

    public string name;

    float currentFraction = 1.0f;
    public float imageFill = 0.0f;

    Text enemyName;
    Image barImage;

    private void Awake()
    {
        vida = vidaInicial;
        vidaFase2 = vidaInicial / 3 * 2;
        vidaFase3 = vidaInicial / 3;
        enemyName = GameObject.FindWithTag("enemyName").GetComponent<Text>();
        barImage = GameObject.FindWithTag("enemyHealth").GetComponent<Image>();
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
            barImage.fillAmount = 0;
            enemyName.text = "";
            Destroy(transform.parent.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        vida -= damage;
        enemyName.text = name;
        UpdateBar(vida, vidaInicial);
    }

    void SpawnTurrets()
    {
        transform.parent.GetChild(2).gameObject.SetActive(true);
    }

    void SpawnLasers()
    {
        transform.parent.GetChild(3).gameObject.SetActive(true);
    }

    void UpdateBar(float currentValue, float maxValue)
    {
        currentFraction = currentValue / maxValue;

        if (currentFraction < 0 || currentFraction > 1)
            currentFraction = currentFraction < 0 ? 0 : 1;

        imageFill = currentFraction;

        barImage.fillAmount = imageFill;
    }
}
