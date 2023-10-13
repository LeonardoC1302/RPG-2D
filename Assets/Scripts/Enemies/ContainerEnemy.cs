using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerEnemy : Enemy
{
    public float stopDistance;
    public GameObject enemyPrefab;
    private int enemiesToSpawn;
    void Start()
    {
        enemiesToSpawn = Random.Range(1, 5);
    }
    public override void Update()
    {
        target = GameObject.FindGameObjectWithTag("Gem").transform;
        if(target != null){
            Debug.Log("Moving");
            if(Vector2.Distance(transform.position, target.position) > stopDistance){
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * speedMultiplier * Time.deltaTime);
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
