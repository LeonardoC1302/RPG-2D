using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject itemButton;
    private Inventory inventory;

    void Start(){
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            for(int i = 0; i< inventory.slots.Length; i++){
                if(inventory.quantityPerSlot[i] == 0){
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    inventory.objects[i] = gameObject.tag;
                    inventory.quantityPerSlot[i]++;
                    Destroy(gameObject);
                    break;
                }else if(inventory.quantityPerSlot[i] >= inventory.maxCapacity){
                    Debug.Log("Inventory Full At: " + i);
                }else if(gameObject.tag == inventory.objects[i]){
                    inventory.quantityPerSlot[i]++;
                    Destroy(gameObject);
                    Debug.Log("Object: " + i + " -> " + inventory.quantityPerSlot[i]);
                    break;
                }          
            }
        }
    }

    // Update is called once per frame
    void Update(){
    }
}
