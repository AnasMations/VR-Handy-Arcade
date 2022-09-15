using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject Object;
    public float SpawnDelay;
    public Transform min_X, max_X, min_Z, max_Z;
    private GameManager gameManager;
    private bool isTurnedOn=true;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(SpawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.TimerValue <= 0)
        {
            isTurnedOn=false;
        }
    }

    void Spawn()
    {
        float xPos = Random.Range(min_X.position.x, max_X.position.x);
        float zPos = Random.Range(min_Z.position.z, max_Z.position.z);
        Instantiate(Object, new Vector3(xPos, transform.position.y, zPos) ,Quaternion.identity);
    }

    IEnumerator SpawnCoroutine()
    {
        while(isTurnedOn)
        {
            yield return new WaitForSeconds(Random.Range(SpawnDelay-1f, SpawnDelay+1f));
            Spawn();
        }
    }
}
