using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 direction;
    public int damage;
    public float range;
    private int bulletType; // 0 = enemy, 1 = defense
    public Transform source;
    public bool canHitFlying = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void setDirection(Vector2 direction){
        this.direction = direction;
    }

    public void setDamage(int damage){
        this.damage = damage;
    }

    public void setCanHitFlying(bool canHitFlying){
        this.canHitFlying = canHitFlying;
    }

    public void setRange(float range){
        this.range = range;
    }

    public void setSource(Transform source){
        this.source = source;
    }

    public void setBulletType(int bulletType){
        this.bulletType = bulletType;
    }

    private void Update(){
        // Check if the bullet distance from the spawn point is greater than the range
        if(source == null){
            Destroy(gameObject);
            return;
        }
        if(Vector2.Distance(transform.position, source.position)/0.32 > range){
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed; // Move the bullet
    }
    void OnTriggerEnter2D(Collider2D other){
        if(bulletType == 0){
            Defense defense = other.GetComponent<Defense>();
            if(defense != null){
                defense.takeDamage(damage);
                Destroy(gameObject);
            }
        } else if(bulletType == 1){
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy != null){
                if(!canHitFlying && enemy.isFlying) return;
                enemy.takeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
