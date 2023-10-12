using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Defense : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public int damage;
    public float timeBetweenAttacks;
    public int cost;
    [HideInInspector]
    public Transform target;
    private TileScript tile;
    [SerializeField] private HealthBar healthBar;

    private void Awake() {
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetTarget(transform);
        maxHealth = health;
    }
    public virtual void Update(){
        target = getCloserTarget();
    }

    public void takeDamage(int damage) {
        health -= damage;
        healthBar.UpdateHealth(health, maxHealth);
        if (health <= 0) {
            DestroyDefense();
        }
    }

    public void setTile(TileScript tile) {
        this.tile = tile;
    }

    public void DestroyDefense() {
        Destroy(gameObject);
        if(tile != null) this.tile.isOccupied = false;
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
