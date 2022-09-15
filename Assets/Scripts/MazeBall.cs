using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBall : MonoBehaviour
{
    public float Speed;
    private float tempSpeed;
    private Vector3 direction;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        tempSpeed = Speed;
        Speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.TimerValue <= 0)
        {
            Speed = 0;
        }
        
        transform.position += direction * Speed * Time.deltaTime;
    }

    public void MoveForward()
    {
        Speed = tempSpeed;
        direction = transform.forward;
        FindObjectOfType<AudioManager>().Play("button");
    }

    public void MoveBackward()
    {
        Speed = tempSpeed;
        direction = -transform.forward;
        FindObjectOfType<AudioManager>().Play("button");
    }

    public void MoveRight()
    {
        Speed = tempSpeed;
        direction = transform.right;
        FindObjectOfType<AudioManager>().Play("button");
    }

    public void MoveLeft()
    {
        Speed = tempSpeed;
        direction = -transform.right;
        FindObjectOfType<AudioManager>().Play("button");
    }

    public void StopMovement()
    {
        Speed = 0;
        FindObjectOfType<AudioManager>().Play("button2");
    }
}
