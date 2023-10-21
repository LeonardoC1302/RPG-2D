using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankEnemy : Enemy
{
    private float attackTime;
    public int shield;
    public int maxShield;
    [SerializeField] private HealthBar shieldBar;

    private void Awake(){
        shieldBar = GetComponentInChildren<HealthBar>();
        shieldBar.SetTarget(transform);
        maxShield = shield;
    }

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
        if(isTarget) damage *= 2;
        if(shield > 0){
            shield -= damage;
            shieldBar.UpdateHealth(shield, maxShield);
        }else{
            base.takeDamage(damage);
        }
    }
}
