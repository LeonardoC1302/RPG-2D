using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    private bool click = false;

    private void Start(){
        canvasGroup.alpha = 0.1f; 
        canvasGroup.blocksRaycasts = false; 
    }

    void Update(){
        if(click){
            canvasGroup.alpha = 1f;
        }else{

        }
    }

    public void clicked(){
        click = true;
    }
}
