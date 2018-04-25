using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class SkillsJugador : MonoBehaviour {

    Image habilidades;
    Habilidades player;
    GameManager manager;

    void Start () {
        habilidades = GetComponent<Image>();
        player = GameObject.FindWithTag("Player").GetComponent<Habilidades>();
        manager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
	}
	
	void Update () {
        if (manager.currentEnergy < player.gasto)
            habilidades.color = new Color(habilidades.color.r, habilidades.color.g, habilidades.color.b, 15);
        else
            habilidades.color = new Color(habilidades.color.r, habilidades.color.g, habilidades.color.b, 255);
    }
}
