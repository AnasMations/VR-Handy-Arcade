using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHead : MonoBehaviour
{
    public float MinTime, MaxTime;
    public Transform UpPos, DownPos;
    private bool isHidden=false;
    private bool isTurnedOn=true;
    private float changePosDelay;
    private CapsuleCollider capsuleCollider;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(ChangePosCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.TimerValue <= 0)
        {
            isTurnedOn=false;
            if(!isHidden)
            {
                ChangePos();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hammer"))
        {
            ChangePos();
            gameManager.score += 10;
            FindObjectOfType<AudioManager>().Play("catMeow");
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
        while(isTurnedOn)
        {
            changePosDelay = Random.Range(MinTime, MaxTime);
            yield return new WaitForSeconds(changePosDelay);

            ChangePos();
        }
    }
}
