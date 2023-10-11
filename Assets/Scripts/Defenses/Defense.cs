using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    public int health;
    public int damage;
    public float timeBetweenAttacks;
    public int cost;
    [HideInInspector]
    public Transform target;
    public virtual void Start(){
        // target = GameObject.FindGameObjectWithTag("Enemy").transform; // Enemy can be null
    }

    public void takeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
