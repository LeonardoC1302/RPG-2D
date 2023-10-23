using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShake : MonoBehaviour
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
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearby = false;
        }
    }

    void Update()
    {
        if(isNearby && Input.GetKeyDown(KeyCode.E)){
            animator.SetBool("Shake", true);
        }else{
            animator.SetBool("Shake", false);
        }
    }
}
