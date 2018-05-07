using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private float lifeTime = 5;
    private int damage;
    private bool onFloor;
    // Use this for initialization
    void Start()
    {
        damage = 10;
        onFloor = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (onFloor)
        {
            lifeTime -= Time.deltaTime;
        }
        if (lifeTime <= 0 || transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Untagged")
        {
            onFloor = true;
        }
    }

    public int GetDamage()
    {
        return damage;
    }
}
