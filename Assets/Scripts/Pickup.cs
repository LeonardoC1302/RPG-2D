using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other){
        //Debug.Log("Collision");
        if(other.CompareTag("Player")){
            for(int i = 0; i< inventory.slots.Length; i++){
                if(!inventory.isFull[i]){
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    inventory.isFull[i] = true;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
