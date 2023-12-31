using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform destination;
    private bool isNearby;
    private Collider2D player;
 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearby = true;
            player = other;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearby = false;
        }
    }

    void Update()
    {
        if(isNearby && Input.GetKeyDown(KeyCode.E)){
            player.transform.position = destination.position;
        }
    }
}
