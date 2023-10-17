using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeEnemy : Enemy
{

    private bool isExploding = false;
    public float explosionRange;
    public override void Update()
    {
        base.Update();
        if(!isInRange(target)){
            move();
        }else{
            if(!isExploding){
                speed=0;
                Explode();
            }
        }
    }

    public override void takeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Explode();
        }
    }

    private void Explode(){
        isExploding = true;
        range = explosionRange;
        animator.SetTrigger("Explode");

        Defense[] targets = FindObjectsOfType<Defense>();
        foreach(Defense target in targets){
            if(isInRange(target.transform)){
                target.takeDamage(target.maxHealth / 2);
            }
        }

    }
}
