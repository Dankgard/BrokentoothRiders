using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour {


    GameManager manager;

    Image barImage;
    public Color barColor = Color.white;

    float currentFraction = 1.0f;
    float imageFill = 0.0f;

    void Start()
    {
        manager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        barImage = GetComponent<Image>();
    }

    public void LoadHealth()
    {
        UpdateBar(manager.currentHealth, manager.initialHealth);
    }

    void UpdateBar(float currentValue, float maxValue)
    {
        currentFraction = currentValue / maxValue;

        if (currentFraction < 0 || currentFraction > 1)
            currentFraction = currentFraction < 0 ? 0 : 1;

        imageFill = currentFraction;

        barImage.fillAmount = imageFill;
    }

    public void Reload(float maxValue)
    {
        barImage.fillAmount = maxValue;
    }
}
