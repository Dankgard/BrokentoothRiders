using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class VidaEnemigo : MonoBehaviour {

    public float vidaInicial;
    float vida;

    public bool isBoss = false;
    public string escena;
    bool cargando = false;

    public string name;

    float currentFraction = 1.0f;
    public float imageFill = 0.0f;

    Text enemyName;
    Image barImage;

    public ExplosionNoLetal explosion;

    private void Awake()
    {
        enemyName = GameObject.FindWithTag("enemyName").GetComponent<Text>();
        barImage = GameObject.FindWithTag("enemyHealth").GetComponent<Image>();
        vida = vidaInicial;
    }
    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            if(isBoss)
                GameManager.instance.StartLoadingScene(escena,5);
            barImage.fillAmount = 0;
            enemyName.text = "";
            ExplosionNoLetal boom = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        vida -= damage;
        enemyName.text = name;
        UpdateBar(vida, vidaInicial);
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
