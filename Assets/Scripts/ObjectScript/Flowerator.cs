using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowerator : MonoBehaviour {
    [SerializeField] GameObject flowerPrefab;
    [SerializeField] GameObject shootPosition;
    private GameObject flower;
    private float fireTime;
    private int fireRate;
    private bool canShoot;
    private int speed;
    private int clip;
    private int magazine;
    private float reloadTime = 3;
    private bool reloading;
    private int ammo;
    // Use this for initialization
    void Start () {
        fireRate = 1;
        fireTime = fireRate;
        canShoot = true;
        speed = 40;
        clip = 10;
        magazine = clip;
        reloading = false;
        ammo = 20;
	}
	
	// Update is called once per frame
	void Update () {
        if (!canShoot)
        {
            fireTime -= Time.deltaTime;
        }
        if (fireTime <= 0)
        {
            canShoot = true;
            fireTime = fireRate;
        }
        if (Input.GetMouseButtonDown(0) && canShoot && magazine > 0 && !reloading)
        {
            canShoot = false;
            flower = Instantiate(flowerPrefab, shootPosition.transform.position,transform.rotation,transform.parent.parent.parent);
            flower.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * speed;
            magazine--;
        }
        if (Input.GetKeyDown(KeyCode.R) && ammo > 0)
        {
            reloading = true;
        }
        if (reloading)
        {
            reloadTime -= Time.deltaTime;
        }
        if (reloadTime <= 0)
        {
            ReloadWeapon();
            reloadTime = 3;
        }
	}

    private void ReloadWeapon()
    {
        if (clip - magazine < ammo)
        {
            ammo -= clip - magazine;
            magazine = clip;
        }
        else
        {
            magazine += ammo;
            ammo = 0;
        }
        reloading = false;
    }
    public int GetMagazine()
    {
        return magazine;
    }
    public int GetAmmo()
    {
        return ammo;
    }
    public void AddAmo(int amm)
    {
        ammo += amm;
    }
}
