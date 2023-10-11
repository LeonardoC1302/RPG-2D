using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int health;
    public float speed = 1f;
    public float speedMultiplier = 1f;
    public int itemIndex = 0;
    private float lastStick;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private Inventory inventory;
    private float lastThrow;
    private GameObject itemThrow;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();  
        inventory = rb.GetComponent<Inventory>();
    }

    public void setItemThrow(GameObject item){
        Debug.Log("Item Set");
        itemThrow = item;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.normalized.sqrMagnitude); // Speed is the magnitude of the vector

        if (Input.GetKey(KeyCode.Space) && Time.time > lastThrow + 0.25f && itemThrow != null){
            throwStick(itemThrow);
            lastThrow = Time.time;
        }
    
    }

    private void FixedUpdate(){
        rb.MovePosition(rb.position + movement * speed * speedMultiplier * Time.fixedDeltaTime);
    }

 
    public void throwStick(GameObject item){
        Vector3 direction;
        direction = movement;
            
        if(movement.x != 0.0f || movement.y != 0.0f){
            GameObject stick = Instantiate(item, transform.position + direction * 0.25f, Quaternion.identity);
            stick.GetComponent<Stick>().SetDirection(direction);
            inventory.quantityPerSlot[itemIndex]--;
        }else{
            direction = new Vector3(0f, -1f, 0f);
            GameObject stick = Instantiate(item, transform.position + direction * 0.25f, Quaternion.identity);
            stick.GetComponent<Stick>().SetDirection(direction);
            inventory.quantityPerSlot[itemIndex]--;;
        }
    }

    public void takeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}


