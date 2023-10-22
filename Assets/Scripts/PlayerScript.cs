using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int health;
    public float speed = 1f;
    public float speedMultiplier = 1f;
    private float lastStick;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private Inventory inventory;
    private float lastThrow;
    private GameObject itemThrow;
    private int itemThrowIndex;
    private Inventory playerInv;

    //UI Elements
    private bool isNearbyT = false;
    public GameObject interactPrompt;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();  
        inventory = rb.GetComponent<Inventory>();
        playerInv = gameObject.GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Teleport"))
        {
            isNearbyT = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Teleport"))
        {
            isNearbyT = false;
        }
    }

    public void setItemThrow(GameObject item){
        Debug.Log("Item Set");
        itemThrow = item;
    }

    public void setItemIndex(int i){
        itemThrowIndex = i;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.normalized.sqrMagnitude); // Speed is the magnitude of the vector

        /*if (Input.GetKey(KeyCode.Space) && Time.time > lastThrow + 0.25f && itemThrow != null){
            throwItem(itemThrow);
            lastThrow = Time.time;
        }*/
        if (isNearbyT && interactPrompt.activeSelf)
        {
            Vector3 playerPosition = gameObject.transform.position;
            interactPrompt.transform.position = new Vector3(playerPosition.x + 0.2f, playerPosition.y + 0.1f, playerPosition.z);
        }
        
        if(isNearbyT){
            appearPrompt();
        }else{
            removePrompt();
        }
    }
    /*
    private void throwItem(GameObject item){
        Vector3 direction;
        direction = movement;
        if(playerInv.quantityPerSlot[itemThrowIndex] > 0){
            if(movement.x != 0.0f || movement.y != 0.0f){
                GameObject throwable = Instantiate(item, transform.position + direction * 0.25f, Quaternion.identity);
                throwable.GetComponent<Pickup>().setDirection(direction);
            }else{
                direction = new Vector3(0f, -1f, 0f);
                GameObject throwable = Instantiate(item, transform.position + direction * 0.25f, Quaternion.identity);
                throwable.GetComponent<Pickup>().setDirection(direction);
            }
            playerInv.ReduceItems(itemThrowIndex);
        }
    }
    */
    private void FixedUpdate(){
        rb.MovePosition(rb.position + movement * speed * speedMultiplier * Time.fixedDeltaTime);
    }

    public void takeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    private void appearPrompt(){
        interactPrompt.SetActive(true);
    }

    private void removePrompt(){
        interactPrompt.SetActive(false);
    }
}


