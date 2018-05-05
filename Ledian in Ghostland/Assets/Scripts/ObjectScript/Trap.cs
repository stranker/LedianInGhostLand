using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Trap : MonoBehaviour {
    private int points;
	// Use this for initialization
	void Start () {
        points = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<FirstPersonController>().TakeDamage(50);
        }
    }

    public void OnDestroy()
    {
        GameManager.SetPoints(GameManager.GetPoints() + points);
    }
}
