using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerEnemy : Enemy
{
    public GameObject enemyPrefab;
    private int enemiesToSpawn;
    void Start()
    {
        enemiesToSpawn = Random.Range(3, 6);
    }
    public override void Update()
    {
        target = GameObject.FindGameObjectWithTag("Gem").transform;
        if(target != null){
            if(!isInRange(target)){
                move();
            }else {
                Die();
            }
        }
    }

    public override void Die(){
        for(int i = 0; i < enemiesToSpawn; i++){
            // Spawn enemies around the container
            Vector2 spawnPosition = new Vector2(transform.position.x + Random.Range(-1f, 1f), transform.position.y + Random.Range(-0.5f, 0.5f));
            Instantiate(enemyPrefab, spawnPosition, transform.rotation);
        }
        Destroy(gameObject);
    }
}
