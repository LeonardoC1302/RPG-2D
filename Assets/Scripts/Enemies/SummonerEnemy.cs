using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class SummonerEnemy : Enemy
{
    public float timeBetweenSummons;
    private float summonTime;
    public Enemy enemyToSummon;
    private Vector2 spawnPosition;
    public override void Update()
    {
        base.Update();
        if(target != null){
            if(!isInRange(target)){
                animator.SetBool("isMoving", true);
                move();
            } else{
                animator.SetBool("isMoving", false);
                if(Time.time >= summonTime){
                    animator.SetBool("isAttacking", true);
                    summonTime = Time.time + timeBetweenSummons;
                }

            }
        }
    }

    public void Summon(){
        if(target != null){
            // spawn position is the position of the summoner + an offset to the direction of the target
            spawnPosition = transform.position + (target.position - transform.position).normalized * 0.3f;
            Instantiate(enemyToSummon, spawnPosition, transform.rotation);
            animator.SetBool("isAttacking", false);
        }
    }
}
