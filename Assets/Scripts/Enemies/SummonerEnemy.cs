using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerEnemy : Enemy
{
    public float stopDistance;
    public float timeBetweenSummons;
    private float summonTime;
    public Enemy enemyToSummon;
    private Vector2 spawnPosition;
    public override void Update()
    {
        base.Update();
        if(target != null){
            if(Vector2.Distance(transform.position, target.position) > stopDistance){
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * speedMultiplier * Time.deltaTime);
            } else{ //spawn minions
                if(Time.time >= summonTime){
                    Summon();
                    summonTime = Time.time + timeBetweenSummons;
                }

            }
        }
    }

    public void Summon(){
        if(target != null){
            spawnPosition.x = transform.position.x;
            spawnPosition.y = transform.position.y;
            Enemy newEnemy = Instantiate(enemyToSummon, spawnPosition, transform.rotation);
        }
    }
}
