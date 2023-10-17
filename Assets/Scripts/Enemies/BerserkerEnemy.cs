using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BerserkerEnemy : Enemy
{
    private float attackTime;
    private bool rage;
    private bool isTransforming;
    private int maxHealth;
    private float healthMultiplier = 1;

    public override void Start(){
        base.Start();
        maxHealth = health;
    }

    public override void Update(){
        base.Update();

        checkTransformation();

        if(target != null){
            if(!isInRange(target)){
                animator.SetBool("isMoving", true);
                move();
            } else{
                animator.SetBool("isMoving", false);
                if(Time.time >= attackTime){
                    animator.SetBool("isAttacking", true);
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
    }

    private void checkTransformation(){
        if(health<= maxHealth/2 && !rage){
            isTransforming = true;
            animator.SetBool("isTransforming", true);
        }
    }

    private void endTransformation(){
        animator.SetBool("isRaged", true);
        rage = true;
        animator.SetBool("isTransforming", false);
        isTransforming = false;
        
        speed = speed * 2;
        health = (int)Mathf.Floor( (maxHealth/2) * healthMultiplier );
        range = 1f;
        timeBetweenAttacks = 1.5f;
    }

    public void Attack(){
        if(target == null) return;
        target.GetComponent<Defense>().takeDamage(damage);
        if(rage){
            health += damage/6;
        }
    }

    public void drinkCoffee(){
        damage += 1;
        healthMultiplier += 0.05f;
        animator.SetBool("isAttacking", false);
    }

    public void endAttack(){
        animator.SetBool("isAttacking", false);
    }

    public override void takeDamage(int damage){
        if(!isTransforming){
            if(rage){
                base.takeDamage(damage/2);
            } else{
                base.takeDamage(damage);
            }
        }
    }


}
