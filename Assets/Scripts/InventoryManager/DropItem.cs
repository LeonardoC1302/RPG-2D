using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    private int index = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Drop(){
        Vector2 playerPos = new Vector2(player.position.x, player.position.y - 0.3f);
        Instantiate(item, playerPos, Quaternion.identity);
    }

    public void setItem(GameObject item){
        PlayerScript character = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        Inventory inventory = character.GetComponent<Inventory>();
        GameObject slot = transform.parent.gameObject;
        for(int i = 0; i<inventory.slots.Length; i++){
            if(inventory.slots[i].Equals(slot)){
                index = i;
            }
        }
        Debug.Log(index);
        character.setItemThrow(item);
        character.setItemIndex(index);
    }

}
