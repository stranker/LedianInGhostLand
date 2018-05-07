using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Fantasma : MonoBehaviour {
    [SerializeField] private int speed;
    [SerializeField] private float timeMove;
    [SerializeField] private Vector3 direction;

    private int life;
    private int points;
    // Use this for initialization
    void Start () {
        speed = 2;
        timeMove = 3;
        direction = Vector3.zero;
        NewDirection();
        life = 30;
        points = 200;
        transform.localScale = new Vector3(7, 7, 7);
    }
	
	// Update is called once per frame
	void Update () {

        timeMove -= Time.deltaTime;
        if (timeMove <= 0)
        {
            NewDirection();
            timeMove = 3;
        }
	}

    private void NewDirection()
    {
        direction.x = UnityEngine.Random.Range(-1.0f, 1.0f);
        direction.z = UnityEngine.Random.Range(-1.0f, 1.0f);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,transform.position + direction.normalized * speed,Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<FirstPersonController>().TakeDamage(10);
        }
        if (other.tag == "Flower")
        {
            life -= other.gameObject.GetComponent<Flower>().GetDamage();
            Destroy(other.gameObject);
            if (life <= 0)
            {
                GameManager.ghostKilled++;
                GameManager.gamePoints += points;
                Destroy(this.gameObject);
            }
        }
    }
}
