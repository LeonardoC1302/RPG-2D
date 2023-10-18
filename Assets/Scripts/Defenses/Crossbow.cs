using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Crossbow : Turret
{
    public override Transform getCloserTarget(){
        float minDistance = float.MaxValue;
        Enemy closerEnemy = null;

        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy enemy in enemies){
            if(!enemy.isFlying) continue;
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
