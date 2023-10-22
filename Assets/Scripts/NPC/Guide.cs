using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    private Animator animator;
    private bool isNearby;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearby = true;
            //Debug.Log("true");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearby = false;
            //Debug.Log("false");
        }
    }

    void Update()
    {
        if(isNearby){
            animator.SetBool("Appear", true);
        }else{
            animator.SetBool("Appear", false);
        }
    }
}
