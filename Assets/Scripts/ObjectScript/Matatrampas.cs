using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matatrampas : MonoBehaviour {
    [SerializeField] private int distance;
    private int clip;
    private int magazine;
    private int ammo;
    private bool reloading;
    private float reloadTime = 2;
	// Use this for initialization
	void Start () {
        distance = 5;
        clip = 5;
        magazine = clip;
        ammo = 20;
        reloading = false;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right, out hit, distance))
        {
            if (Input.GetMouseButtonDown(0) && magazine > 0 && !reloading)
            {
                if (hit.transform.tag == "Trap")
                {
                    Destroy(hit.transform.gameObject);
                    magazine--;
                    GameManager.gamePoints += hit.transform.GetComponent<Trap>().GetPoints();
                    GameManager.trapsDesactivated++;
                }
            }
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
