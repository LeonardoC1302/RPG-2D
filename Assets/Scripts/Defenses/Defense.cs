using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Defense : MonoBehaviour
{
    public float range;
    public int maxHealth;
    public int health;
    public int damage;
    public float timeBetweenAttacks;
    public int cost;
    [HideInInspector]
    public Transform target;
    private TileScript tile;
    [SerializeField] private HealthBar healthBar;
    public bool canHitFlying = false;
    public int level = 1;

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

    public virtual Transform getCloserTarget(){
        float minDistance = float.MaxValue;
        Enemy closerEnemy = null;

        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy enemy in enemies){
            if(enemy.isFlying && !canHitFlying) continue;
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if(distance < minDistance){
                minDistance = distance;
                closerEnemy = enemy;
            }
        }

        if(closerEnemy != null) return closerEnemy.transform;
        return null;
    }

    private void OnMouseDown(){
        if(this.GetComponent<GemScript>() != null) return; // If it's a gem, don't show info
        DefenseInfo.ShowInfo(this);
    }

    public bool isInRange(Transform target){
        if(Vector2.Distance(transform.position, target.position)/0.32 < range) return true;
        return false;
    }

    public void increaseLevel(int levels){
        level += levels;
        for(int i = 0; i < levels; i++){
            increaseStats();
        }
        healthBar.SetLevel(level);
    }

    private void increaseStats(){
        damage += (int)( 0.5 * (float)(level-1) );
        health += 10;
        timeBetweenAttacks -= 0.1f;
    }

    public void Heal(int amount){
        health += amount;
        if(health > maxHealth) health = maxHealth;
        healthBar.UpdateHealth(health, maxHealth);
    }

    public void IncreaseDamage(int amount){
        damage += amount;
    }

    public void IncreaseSpeed(float amount){
        timeBetweenAttacks -= amount;
    }
}
