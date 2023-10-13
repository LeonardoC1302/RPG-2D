using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionEnemy : Enemy
{
    public float stopDistance;
    private float attackTime;
    private int maxHealth;

    public void Start(){
        maxHealth = health;
    }
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

    public void setHealth(int health){
        if(health <= 0) health = 1;
        this.health = health;
        this.maxHealth = health;
    }

    public override void Die(){
        if(maxHealth == 1){
            base.Die();
            return;
        }
        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + 0.5f);
        GameObject clone1 = Instantiate(gameObject, spawnPosition, transform.rotation);
        spawnPosition = new Vector2(transform.position.x, transform.position.y - 0.5f);
        GameObject clone2 = Instantiate(gameObject, spawnPosition, transform.rotation);
        clone1.GetComponent<DivisionEnemy>().setHealth(maxHealth/2);
        clone2.GetComponent<DivisionEnemy>().setHealth(maxHealth/2);
        Destroy(gameObject);
    }

    
}
