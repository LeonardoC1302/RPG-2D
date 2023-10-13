using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Defense
{
    private float attackTime;
    public GameObject bullet;

    public override void Update()
    {
        base.Update();
        Rotate();
        if(target != null){
            if(Time.time >= attackTime && Vector2.Distance(transform.position, target.position)/0.32 < range){
                Shoot();
                attackTime = Time.time + timeBetweenAttacks;
            }
        }
    }

    public void Shoot(){
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject proyectile = Instantiate(bullet, transform.position+(Vector3)direction*0.2f, rotation);
        proyectile.GetComponent<ProyectileScript>().setDirection(direction);
        proyectile.GetComponent<ProyectileScript>().setDamage(damage);
        proyectile.GetComponent<ProyectileScript>().setBulletType(1);
    }

    public void Rotate(){
        if(target != null){
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
             transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
