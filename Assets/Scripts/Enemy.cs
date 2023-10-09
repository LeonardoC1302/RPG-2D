using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public float speed;

    [HideInInspector]
    public Transform target;
    private void Start(){
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log("Target: " + target);
    }
    public void takeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
