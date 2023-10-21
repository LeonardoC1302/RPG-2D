using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Executioner : Enemy
{
    public float meleeRange;
    public float summonRange;
    //public float timeBetweenAttacks;
    public float timeBetweenSummons;
    public float timeBetweenDodges;
    private float dodgeTime;
    private float attackTime;
    private float summonTime;
    private bool isDodging;
    public int shield;
    public int maxShield;
    // public int health;
    // public int damage;
    // public float speed;
    // public float speedMultiplier;
    public Enemy enemyToSummon;
    private Vector2 spawnPosition;
    [SerializeField] private HealthBar shieldBar;

    public float dodgeProbability;


    public void Awake(){
        shieldBar = GetComponentInChildren<HealthBar>();
        shieldBar.SetTarget(transform);
        maxShield = shield;
    }

    public override void Update()
    {
        base.Update();
        if(target != null){
            if(!isInMeleeRange(target)){
                // Choose if move or summon
                if(isInSummonRange(target)){
                    if(Time.time >= summonTime){
                        float random = Random.Range(0, 100);
                        Debug.Log(random);
                        if(random <= 50){
                            animator.SetBool("isSummoning", true);
                        }
                        summonTime = Time.time + timeBetweenSummons;
                    } else{
                        move();
                    }
                }else{
                    move();
                }
            } else{
                if(Time.time >= attackTime){
                    animator.SetBool("isAttacking", true);
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
    }

    public override void takeDamage(int damage)
    {
        if(isDodging) return;
        if(Time.time >= dodgeTime){
            float random = Random.Range(0, 100);
            if(random <= dodgeProbability){
                if(shield >0){
                    shield = Mathf.Max(shield, maxShield/2);
                }else{
                    health+=damage*5;
                }
                animator.SetBool("isDodging", true);
                isDodging = true;
                dodgeTime = Time.time + timeBetweenDodges;
                return;
            }
        }
        if(shield > 0){
            shield -= damage;
            shieldBar.UpdateHealth(shield, maxShield);
        }else{
            base.takeDamage(damage);
        }
    }

    public bool isInMeleeRange(Transform target){
        if(Vector2.Distance(transform.position, target.position)/0.32 < meleeRange) return true;
        return false;
    }

    public bool isInSummonRange(Transform target){
        if(Vector2.Distance(transform.position, target.position)/0.32 < summonRange) return true;
        return false;
    }

    public void Attack(){
        if(target == null) return;
        target.GetComponent<Defense>().takeDamage(damage);
        if(shield > 0){
            shield += damage/4;
        }else{
            health += damage/4;
        }
    }

    public void endAttack(){
        animator.SetBool("isAttacking", false);
    }

    public void endDodge(){
        animator.SetBool("isDodging", false);
        isDodging = false;
    }

    public void Summon(){
        spawnPosition = transform.position + (target.position - transform.position).normalized * 0.3f;
        Instantiate(enemyToSummon, spawnPosition, Quaternion.identity);
        animator.SetBool("isSummoning", false);
    }
}
