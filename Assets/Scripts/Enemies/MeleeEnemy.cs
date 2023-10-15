using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    private float attackTime;

    public override void Update()
    {
        base.Update();
        if(target != null){
            if(!isInRange(target)){
                animator.SetBool("isMoving", true);
                move();
            }else {
                animator.SetBool("isMoving", false);
                if(Time.time >= attackTime){
                    animator.SetTrigger("attack");
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
    }

    public void Attack(){
        target.GetComponent<Defense>().takeDamage(damage);
    }
}
