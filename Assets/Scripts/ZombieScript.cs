using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : Enemy
{
    public float stopDistance;
    // Update is called once per frame
    void Update()
    {
        if(target != null){
            if(Vector2.Distance(transform.position, target.position) > stopDistance){
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }
}
