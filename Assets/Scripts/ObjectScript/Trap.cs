using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Trap : MonoBehaviour {
    private int points;
	// Use this for initialization
	void Start () {
        points = 100;
        transform.localScale = new Vector3(1.5f,1.5f, 1.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 knockDirection = other.transform.position - transform.position;
            knockDirection = knockDirection.normalized;
            other.gameObject.GetComponent<FirstPersonController>().TakeDamage(50);
            other.gameObject.GetComponent<FirstPersonController>().KnockBack(knockDirection);
        }
    }

    public int GetPoints()
    {
        return points;
    }
}
