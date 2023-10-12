using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 direction;
    public int damage;
    private int bulletType; // 0 = enemy, 1 = defense


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

    public void setBulletType(int bulletType){
        this.bulletType = bulletType;
    }

    // private void Update(){
    //     if(Vector2.Distance(transform.position, targetPosition) > .1f){
    //         transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    //     }else {
    //         Destroy(gameObject);
    //     }
    // }

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
                enemy.takeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
