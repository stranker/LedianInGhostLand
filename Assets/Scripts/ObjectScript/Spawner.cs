using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject ghost;
    [SerializeField] GameObject trap;
    private float timeSpawnGhost;
    private float timeSpawnTraps;
    // Use this for initialization
    void Start()
    {
        timeSpawnGhost = UnityEngine.Random.Range(8, 10);
        timeSpawnTraps = UnityEngine.Random.Range(6, 10);
    }

    // Update is called once per frame
    void Update()
    {
        timeSpawnGhost -= Time.deltaTime;
        timeSpawnTraps -= Time.deltaTime;
        if (timeSpawnGhost <= 0)
        {
            CreateGhost();
            timeSpawnGhost = UnityEngine.Random.Range(8, 10);
        }
        if (timeSpawnTraps <= 0)
        {
            CreateTrap();
            timeSpawnTraps = UnityEngine.Random.Range(6, 10);
        }
    }

    private void CreateTrap()
    {
        Vector3 position = Vector3.zero;
        position.x = transform.position.x + UnityEngine.Random.Range(-100, 100);
        position.z = transform.position.z + UnityEngine.Random.Range(-100, 100);
        position.y = trap.transform.position.y;
        Instantiate(trap, position, transform.rotation, transform);
    }

    private void CreateGhost()
    {
        Vector3 position = Vector3.zero;
        position.x = transform.position.x + UnityEngine.Random.Range(-100, 100);
        position.z = transform.position.z + UnityEngine.Random.Range(-100, 100);
        position.y = 4;
        Instantiate(ghost, position, transform.rotation, transform);
    }
}
