using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    public float dodgeProbability;
    private float attackTime;

    public override void Update()
    {
        base.Update();
        if(target != null){
            if(!isInRange(target)){
                move();
            }else {
                if(Time.time >= attackTime){
                    animator.SetBool("isAttacking", true);
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
    }

    public void Attack(){
        if(target == null) return;
        target.GetComponent<Defense>().takeDamage(damage);
        animator.SetBool("isAttacking", false);
    }

    public override void takeDamage(int damage)
    {
        float random = Random.Range(0, 100);
        if(random <= dodgeProbability){
            Debug.Log("Dodge");
            return;
        }
        base.takeDamage(damage);
    }
}
