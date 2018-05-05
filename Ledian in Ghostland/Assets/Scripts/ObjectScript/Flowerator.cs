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
    // Use this for initialization
    void Start () {
        fireRate = 2;
        fireTime = fireRate;
        canShoot = true;
        speed = 40;
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
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            canShoot = false;
            flower = Instantiate(flowerPrefab, shootPosition.transform.position,transform.rotation,transform.parent.parent.parent);
            flower.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * speed;
        }
	}
}
