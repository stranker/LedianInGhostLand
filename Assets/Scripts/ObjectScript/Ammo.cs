using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

    private int rotateSpeed = 40;
	// Update is called once per frame
	void Update () {
        transform.Rotate(transform.up, Time.deltaTime * rotateSpeed);
	}
}
