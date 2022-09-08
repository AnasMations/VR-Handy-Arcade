using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoint : MonoBehaviour
{
    public GameObject followPoint;
    public float speed;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, followPoint.transform.position)>0.15f) transform.LookAt(followPoint.transform);
        Vector3 direction = followPoint.transform.position - transform.position;
        anim.SetFloat("Velocity", Vector3.Distance(transform.position, followPoint.transform.position));
        direction *= speed;
        gameObject.GetComponent<Rigidbody>().velocity = direction;
    }
}
