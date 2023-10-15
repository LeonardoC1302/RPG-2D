using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CostText : MonoBehaviour
{
    public Defense defense;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        textMesh.text = defense.cost.ToString();
    }
}
