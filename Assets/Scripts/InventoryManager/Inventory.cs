using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] slots;
    public string[] objects;
    public int[] quantityPerSlot;

    public int maxCapacity;
    private TextMeshProUGUI num;

    public void increaseInventory(int index){
        quantityPerSlot[index]++;
        num = slots[index].transform.Find("Quantity").GetComponent<TextMeshProUGUI>();
        num.text = quantityPerSlot[index].ToString();
    }

     public void DropItems(int index){
        if(quantityPerSlot[index] > 0){
            quantityPerSlot[index]--;
            num = slots[index].transform.Find("Quantity").GetComponent<TextMeshProUGUI>();
            num.text = quantityPerSlot[index].ToString();
            foreach(Transform child in slots[index].transform){
                if(child.gameObject.name != "Drop" && child.gameObject.name != "Quantity"){
                    child.GetComponent<DropItem>().Drop();
                    if( quantityPerSlot[index] == 0 ){
                        GameObject.Destroy(child.gameObject);
                    }
                }
            }
        }
    }

    public void ReduceItems(int index){
        if(quantityPerSlot[index] > 0){
            quantityPerSlot[index]--;
            num = slots[index].transform.Find("Quantity").GetComponent<TextMeshProUGUI>();
            num.text = quantityPerSlot[index].ToString();
            foreach(Transform child in slots[index].transform){
                if(child.gameObject.name != "Drop" && child.gameObject.name != "Quantity" && quantityPerSlot[index] == 0 ){
                    GameObject.Destroy(child.gameObject);
                }
            }
        }
    }
    
}
