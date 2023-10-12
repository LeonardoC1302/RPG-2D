using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public float stopDistance;
    private float attackTime;

    public override void Update()
    {
        base.Update();
        if(target != null){
            if(Vector2.Distance(transform.position, target.position) > stopDistance){
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * speedMultiplier * Time.deltaTime);
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
