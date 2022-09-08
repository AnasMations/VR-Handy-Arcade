using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    float tempSpeed;
    GameObject Player;
    Animator anim;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        tempSpeed = speed;
        Player = GameObject.FindWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
        transform.LookAt(target);
        transform.position += transform.forward * speed * Time.deltaTime;
        anim.SetFloat("Velocity", Vector3.Distance(gameObject.transform.position, Player.transform.position)/7f);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Attack();
        }else if(other.CompareTag("Bullet"))
        {
            gameManager.score += 1;
            Death();
        }else if(other.CompareTag("Sword"))
        {
            gameManager.score += 1;
            Death();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            speed = tempSpeed;
            anim.SetBool("Attack", false);
        }
    }

    void Death()
    {
        speed = 0;
        anim.SetTrigger("Die");
        Destroy(gameObject, 3f);
    }

    void Attack()
    {
        speed = 0;
        anim.SetBool("Attack", true);
    }
}
