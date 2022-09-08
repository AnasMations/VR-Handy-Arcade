using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject []spawnPoints;
    public float spawnDelay;
    public GameObject objectToSpawn;

    Vector3 spawnPoint;
     
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawn", 1f, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
    }

    void spawn()
    {
        Instantiate(objectToSpawn, spawnPoint, Quaternion.identity);
    }
}
