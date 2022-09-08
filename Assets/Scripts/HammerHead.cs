using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHead : MonoBehaviour
{
    public float MinTime, MaxTime;
    public Transform UpPos, DownPos;
    private bool isHidden=false;
    private float changePosDelay;
    private CapsuleCollider capsuleCollider;
    private GameManager gameManager;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audio = GetComponent<AudioSource>();
        StartCoroutine(ChangePosCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hammer"))
        {
            ChangePos();
            gameManager.score += 10;
            audio.Play();
        }
    }

    void ChangePos()
    {
        if(isHidden)
        {
            //unhide
            transform.position = UpPos.position;
            capsuleCollider.enabled = true;
            isHidden = false;
        }else
        {
            //hide
            transform.position = DownPos.position;
            capsuleCollider.enabled = false;
            isHidden = true;
        }
    }

    IEnumerator ChangePosCoroutine()
    {
        while(true)
        {
            changePosDelay = Random.Range(MinTime, MaxTime);
            yield return new WaitForSeconds(changePosDelay);

            ChangePos();
        }
    }
}
