using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject itemButton;
    public float speed;
    private Inventory inventory;
    private Rigidbody2D Rb;
    private Vector2 direction;

    void Start(){
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        Rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            for(int i = 0; i< inventory.slots.Length; i++){
                if(inventory.quantityPerSlot[i] == 0){
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    inventory.objects[i] = gameObject.tag;
                    inventory.increaseInventory(i);
                    Destroy(gameObject);
                    break;
                }else if(inventory.quantityPerSlot[i] >= inventory.maxCapacity){
                    //Debug.Log("Inventory Full At: " + i);
                }else if(gameObject.tag == inventory.objects[i]){
                    inventory.increaseInventory(i);
                    Destroy(gameObject);
                    //Debug.Log("Object: " + i + " -> " + inventory.quantityPerSlot[i]);
                    break;
                }          
            }
        }
    }
    void Update(){
    }

    private void FixedUpdate(){
        Rb.velocity = direction * speed;
    }

    public void setDirection(Vector2 Direction){
        direction = Direction;
    }

    public void destroyItem(){
        Destroy(gameObject); // Destroy the bullet
    }
}
