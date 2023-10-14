using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemEnemy : Enemy
{
    public Animator enemyAnimator;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            if (enemyAnimator != null){
                enemyAnimator.SetBool("Touch", true);
            }
        }
    }

    public void endAnimation(){
        enemyAnimator.SetBool("Touch", false);;
    }

}
