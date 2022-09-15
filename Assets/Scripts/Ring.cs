using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public int ScorePoints;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            gameManager.score += ScorePoints;
            FindObjectOfType<AudioManager>().Play("star");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.TimerValue <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
