using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikeball : Defense
{
    private float attackTime;

    public override void Update()
    {
        base.Update();
        if(target != null){
            if(Time.time >= attackTime){
                Spike();
                attackTime = Time.time + timeBetweenAttacks;
            }
        }
    }
    void Spike(){
        if(Vector2.Distance(transform.position, target.position) <= 0.3f){
            target.GetComponent<Enemy>().takeDamage(damage);
            Debug.Log("Spikeball hit");
        }
    }
}
