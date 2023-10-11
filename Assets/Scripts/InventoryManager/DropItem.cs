using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Drop(){
        Vector2 playerPos = new Vector2(player.position.x, player.position.y + 0.5f);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
