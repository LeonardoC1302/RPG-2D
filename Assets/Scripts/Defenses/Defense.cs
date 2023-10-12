using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Defense : MonoBehaviour
{
    public int health;
    public int damage;
    public float timeBetweenAttacks;
    public int cost;
    [HideInInspector]
    public Transform target;
    public virtual void Update(){
        target = getCloserTarget();
        if(target != null){
            if(target.position.x < transform.position.x){
                transform.localScale = new Vector3(-1, 1, 1);
            }else if(target.position.x > transform.position.x){
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    public void takeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    public Transform getCloserTarget(){
        float minDistance = float.MaxValue;
        Enemy closerEnemy = null;

        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy enemy in enemies){
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if(distance < minDistance){
                minDistance = distance;
                closerEnemy = enemy;
            }
        }

        if(closerEnemy != null) return closerEnemy.transform;
        return null;
    }
}
