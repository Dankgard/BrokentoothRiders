using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionNoLetal : MonoBehaviour {

    public int destroyTime;

    private void Awake()
    {
        Destroy(gameObject, destroyTime);
    }
}
