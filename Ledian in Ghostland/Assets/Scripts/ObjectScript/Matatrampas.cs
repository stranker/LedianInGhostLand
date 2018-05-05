using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matatrampas : MonoBehaviour {
    [SerializeField] private int distance;
	// Use this for initialization
	void Start () {
        distance = 5;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right, out hit, distance))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.transform.tag == "Trap")
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }

	}
}
