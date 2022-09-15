using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public Vector3 rotation;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            gameManager.score += 10;
            gameManager.TimerValue += 1;
            FindObjectOfType<AudioManager>().Play("star");
            Destroy(gameObject);
        }
    }
}
