using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseInfo : MonoBehaviour
{
    private static DefenseInfo Instance {get; set;}

    private void Awake(){
        Instance = this;
        gameObject.SetActive(false);
    }

    public static void ShowInfo(Defense defense){
        Instance.Show(defense);
    }

    private void Show(Defense defense){
        gameObject.SetActive(!gameObject.activeSelf);
        transform.position = defense.transform.position;
        transform.localScale = defense.range*2* Vector3.one;
    }

}
