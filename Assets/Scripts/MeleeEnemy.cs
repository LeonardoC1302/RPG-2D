using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public float stopDistance;
    private float attackTime;

    void Update()
    {
        if(target != null){
            if(target.position.x < transform.position.x){
                transform.localScale = new Vector3(-1, 1, 1);
            }else if(target.position.x > transform.position.x){
                transform.localScale = new Vector3(1, 1, 1);
            }
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
        target.GetComponent<GemScript>().takeDamage(damage);
    }
}
