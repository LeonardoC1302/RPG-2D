using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItem : MonoBehaviour
{
    public void setItem(GameObject item){
        PlayerScript character = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        Inventory inventory = character.GetComponent<Inventory>();

        GameObject closestSlot = null;
        int index = -1;
        float closestDistance = float.MaxValue;
        for(int i = 0; i<inventory.slots.Length; i++){
            float distance = Vector2.Distance(inventory.slots[i].transform.position, Input.mousePosition);
            if(distance < closestDistance){
                closestDistance = distance;
                closestSlot = inventory.slots[i];
                index = i;
            }
        }

        if(closestSlot != null){
            Debug.Log(index);
            character.setItemThrow(item);
            character.setItemIndex(index);
        }
    }
}
