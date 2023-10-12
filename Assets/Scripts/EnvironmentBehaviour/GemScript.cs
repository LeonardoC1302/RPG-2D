using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : Defense
{
    public override void Update()
    {
        base.Update();
        if(this.health <= 0){
            GameLost();
        }
    }

    public void GameLost(){
        Debug.Log("Game Lost");
    }
}
