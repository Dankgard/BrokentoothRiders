using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmaJugador : MonoBehaviour {

    public Sprite shotgun;
    public Sprite rifle;
    Image arma;

	void Start () {
        arma = GetComponent<Image>();
	}
	
	public void LoadWeapon(bool shotgunActive)
    {
        if (shotgunActive)
            arma.sprite = shotgun;
        else
            arma.sprite = rifle;
    }

}
