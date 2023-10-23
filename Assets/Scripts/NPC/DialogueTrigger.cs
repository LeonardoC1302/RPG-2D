using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueBox;  
    private bool isNearby = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearby = true;
            //Debug.Log("Activate");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearby = false;
            CloseDialogueBox();
        }
    }

    void Update()
    {
        if (isNearby && Input.GetKeyDown(KeyCode.E))  // Check if "E" key is pressed
        {
            OpenDialogueBox();
        }
    }

    void OpenDialogueBox()
    {
        dialogueBox.SetActive(true);
    }

    void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
    }
}
