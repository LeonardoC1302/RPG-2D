using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserGun : Turret
{
    public override Transform getCloserTarget(){
        float maxDistance = float.MinValue;
        Enemy furthestEnemy = null;

        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy enemy in enemies){
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if(distance > maxDistance){
                maxDistance = distance;
                furthestEnemy = enemy;
            }
        }

        if(furthestEnemy != null) return furthestEnemy.transform;
        return null;
    }
}
