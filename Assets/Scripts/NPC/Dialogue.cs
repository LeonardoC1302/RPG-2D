using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float textSpeed;
    private int index = -1;

    void Start(){     
    }

    private void OnEnable(){
        dialogueText.text = string.Empty;
        startDialogue();
    }

    void Update(){
        if(index == -1 && Input.GetKeyDown(KeyCode.E)){
            startDialogue();
        }

        if(Input.GetKeyDown(KeyCode.E)){
            if(dialogueText.text == lines[index]){
                NextLine();
            }else{
                StopAllCoroutines();
                dialogueText.text = lines[index];
            }
        }
    }

    void startDialogue(){
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        foreach(char c in lines[index].ToCharArray()){
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if(index < lines.Length-1){
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }else{
            gameObject.SetActive(false);
            index = -1;
        }
    }
}
