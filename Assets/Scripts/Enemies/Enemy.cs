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
    }
    public void takeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    public Transform getCloserTarget(){
        Defense[] defenses = FindObjectsOfType<Defense>();
        foreach(Defense defense in defenses){
            Debug.Log(defense);
        }

        return null;
    }
}
