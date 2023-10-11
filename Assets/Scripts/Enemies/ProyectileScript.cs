using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileScript : MonoBehaviour
{
    public float speed;
    private GemScript gem;
    private Vector2 targetPosition;
    public int damage;


    void Start()
    {
        gem = GameObject.FindGameObjectWithTag("Gem").GetComponent<GemScript>();
        targetPosition = gem.transform.position;
    }

    private void Update(){
        if(Vector2.Distance(transform.position, targetPosition) > .1f){
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }else {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Gem")){
            gem.takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
