using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    private int index;
    private PlayerScript character;
    private Inventory inventory;
    private GameObject slot;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        inventory = character.GetComponent<Inventory>();
        slot = transform.parent.gameObject;
    }

    public void Drop(){
        Vector2 playerPos = new Vector2(player.position.x, player.position.y - 0.3f);
        Instantiate(item, playerPos, Quaternion.identity);
    }

    public void setItem(GameObject items){
        for(int i = 0; i<inventory.slots.Length; i++){
            if(inventory.slots[i].Equals(slot)){
                index = i;
            }
        }
        //Debug.Log(index);
        character.setItemThrow(items);
        character.setItemIndex(index);
    }

}
