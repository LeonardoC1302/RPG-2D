using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public float speed;
    public float speedMultiplier;

    [HideInInspector]
    public Transform target;
    public virtual void Start(){
        target = GameObject.FindGameObjectWithTag("Gem").transform;
    }
    public void takeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
