using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoRex : MonoBehaviour
{

    public GameObject shotgunBullets;
    public GameObject rifleBullets;
    public float rifleDelay = 0.1f;
    public float shotgunDelay = 0.5f;

    public float shotgunReach = 1;
    public float rifleReach = 2;

    // true escopeta, false fusil
    public bool shotgunActive;

    public float bulletSpeed = 10;

    public bool automaticWeapon;

    float reach;
    float delay;
    Vector3 shootDirection;
    GameObject bullets;
    bool canShoot;

    ArmaJugador spriteArma;

    void Start()
    {
        canShoot = true;
        spriteArma = GameObject.FindWithTag("actualweapon").GetComponent<ArmaJugador>();
        WeaponChange();

    }

    void Update()
    {

        if (Input.GetMouseButton(0) && canShoot && automaticWeapon)
        {
            Disparo();
            Invoke("NewBullet", rifleDelay);

        }

        if (Input.GetMouseButtonUp(0) && !(automaticWeapon) && canShoot)
        {
            Disparo();
            Invoke("NewBullet", shotgunDelay);
        }
    }

    void Disparo()
    {
        shootDirection = Input.mousePosition;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection.z = 0.0f;
        shootDirection = shootDirection - transform.position;

        GameObject bullet = Instantiate(bullets, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        Vector2 dir = shootDirection.normalized;

        bullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed; //shootDirection.normalized * bulletSpeed;
        Destroy(bullet, reach);
        canShoot = false;
    }

    private void NewBullet()
    {
        canShoot = true;
    }

    public void WeaponChange()
    {
        canShoot = true;

        if (shotgunActive)
        {
            bullets = shotgunBullets;
            reach = shotgunReach;
            delay = shotgunDelay;
            automaticWeapon = false;
        }
        else
        {
            bullets = rifleBullets;
            reach = rifleReach;
            delay = rifleDelay;
            automaticWeapon = true;
        }
        spriteArma.LoadWeapon(shotgunActive);
    }
}
