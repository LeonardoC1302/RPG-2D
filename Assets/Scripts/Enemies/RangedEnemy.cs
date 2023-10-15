using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    private float attackTime;
    public GameObject bullet;

    public override void Update()
    {
        base.Update();
        if(target != null){
            if(!isInRange(target)){
                animator.SetBool("isMoving", true);
                move();
            }else {
                animator.SetBool("isMoving", false);
                if(Time.time >= attackTime){
                    animator.SetBool("isAttacking", true);
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }

        }
    }

    public void Shoot(){
        if(target == null) return;
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject proyectile = Instantiate(bullet, transform.position+(Vector3)direction*0.2f, rotation);
        proyectile.GetComponent<ProyectileScript>().setDirection(direction);
        proyectile.GetComponent<ProyectileScript>().setDamage(damage);
        proyectile.GetComponent<ProyectileScript>().setRange(range);
        proyectile.GetComponent<ProyectileScript>().setSource(transform);
        proyectile.GetComponent<ProyectileScript>().setBulletType(0);
    }

    public void LastShoot(){
        Shoot();
        animator.SetBool("isAttacking", false);
    }
}
