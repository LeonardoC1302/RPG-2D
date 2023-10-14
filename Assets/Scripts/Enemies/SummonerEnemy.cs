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
                move();
            } else{
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
