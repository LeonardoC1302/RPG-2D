using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public bool isOccupied;
    public Color green;
    public Color red;
    private SpriteRenderer rend;

    private void Start() {
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update(){
        if(isOccupied){
            rend.color = red;
        } else {
            rend.color = green;
        }
    }
}
