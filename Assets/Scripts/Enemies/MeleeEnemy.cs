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
                move();
            }else {
                if(Time.time >= attackTime){
                    Attack();
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
    }

    public void Attack(){
        target.GetComponent<Defense>().takeDamage(damage);
    }
}
