using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionEnemy : Enemy
{
    private float attackTime;
    private int maxHealth;
    public int divisions;

    public override void Start()
    {
        base.Start();
        maxHealth = health;
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
        target.GetComponent<Defense>().takeDamage(damage);
        animator.SetBool("isAttacking", false);
    }

    public void setHealth(int health){
        if(health <= 0) health = 1;
        this.health = health;
        this.maxHealth = health;
    }

    public void setDivisions(int divisions){
        this.divisions = divisions;
    }

    public override void Die(){
        if(divisions >= 2){
            base.Die();
            return;
        }
        Vector2 direction = (target.position - transform.position).normalized;
        Debug.Log(direction);

        // The enemies will spawn on each side of the original enemy, considering the direction of the target

        Vector2 spawnPosition = new Vector2(transform.position.x + direction.x, transform.position.y + direction.y);
        GameObject clone1 = Instantiate(gameObject, spawnPosition, transform.rotation);
        spawnPosition = new Vector2(transform.position.x - direction.x, transform.position.y - direction.y);
        GameObject clone2 = Instantiate(gameObject, spawnPosition, transform.rotation);
        clone1.GetComponent<DivisionEnemy>().setHealth(maxHealth/2);
        clone1.GetComponent<DivisionEnemy>().setDivisions(divisions+1);
        clone2.GetComponent<DivisionEnemy>().setHealth(maxHealth/2);
        clone2.GetComponent<DivisionEnemy>().setDivisions(divisions+1);
        Destroy(gameObject);
    }

    
}
