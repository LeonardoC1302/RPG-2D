using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public float speed;
    public float speedMultiplier;

    public float timeBetweenAttacks;

    [HideInInspector]
    public Transform target;

    public virtual void Update(){
        target = getCloserTarget();
        if(target != null){
            // if(target.position.x < transform.position.x){
            //     transform.localScale = new Vector3(-1, 1, 1);
            // }else if(target.position.x > transform.position.x){
            //     transform.localScale = new Vector3(1, 1, 1);
            // }
        }
    }
    public void takeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    public Transform getCloserTarget(){
        float minDistance = float.MaxValue;
        Defense closerDefense = null;

        Defense[] defenses = FindObjectsOfType<Defense>();
        foreach(Defense defense in defenses){
            float distance = Vector2.Distance(transform.position, defense.transform.position);
            if(distance < minDistance){
                minDistance = distance;
                closerDefense = defense;
            }
        }
        if(closerDefense != null) return closerDefense.transform;
        return null;
    }

    public virtual void Die(){
        Destroy(gameObject);
    }
}
