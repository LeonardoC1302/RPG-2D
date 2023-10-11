using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public float stopDistance;
    private float attackTime;
    public Transform shotPoint;
    public GameObject bullet;

    public override void Update()
    {
        base.Update();
        if(target != null){
            if(Vector2.Distance(transform.position, target.position) > stopDistance){
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * speedMultiplier * Time.deltaTime);
            }

            if(Time.time >= attackTime){
                Shoot();
                attackTime = Time.time + timeBetweenAttacks;
            }
        }
    }

    public void Shoot(){
        Vector2 direction = target.position - shotPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        shotPoint.rotation = rotation;

        Instantiate(bullet, shotPoint.position+(Vector3)direction*0.2f, shotPoint.rotation);
    }
}
