using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionNoLetal : MonoBehaviour {

    public int destroyTime;

    public AudioClip explosionSound;

    private void Awake()
    {
        SoundManager.instance.PlaySound(explosionSound, 0.4f);
        Destroy(gameObject, destroyTime);
    }
}
