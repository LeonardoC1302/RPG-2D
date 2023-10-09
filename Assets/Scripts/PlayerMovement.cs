using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float speedMultiplier = 1f;
    public GameObject stickP;
    private float lastStick;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private int stickCount = 0;


    private void OnCollisionEnter2D(Collision2D collision){
        
        if(collision.gameObject.CompareTag("Stick")){
            Destroy(collision.gameObject);
            stickCount++;
            Debug.Log("Count: " + stickCount);
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude); // Speed is the magnitude of the vector

        if (Input.GetKey(KeyCode.Space) && stickCount > 0 && Time.time > lastStick + 0.25f){
            throwStick();
            lastStick = Time.time;
        }
    }

    private void FixedUpdate(){
        rb.MovePosition(rb.position + movement * speed * speedMultiplier * Time.fixedDeltaTime);
    }

    private void throwStick(){
        Vector3 direction;
        direction = movement;
            
        if(movement.x != 0.0f || movement.y != 0.0f){
            GameObject stick = Instantiate(stickP, transform.position + direction * 0.2f, Quaternion.identity);
            stick.GetComponent<Stick>().SetDirection(direction);
            stickCount--;
        }
    }
}


