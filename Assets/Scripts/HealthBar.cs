using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private Transform target;

    public void UpdateHealth(int currentHealth, int maxHealth){
        slider.value = (float)currentHealth / (float)maxHealth;
    }

    public void SetTarget(Transform target){
        this.target = target;
    }

    void Update()
    {
        transform.rotation = Quaternion.identity;
        if(target != null && target.GetComponent<GemScript>() == null) transform.position = target.position + new Vector3(0, 0.2f, 0);
    }
}
