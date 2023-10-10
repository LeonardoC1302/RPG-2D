using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rb;
    private Vector2 Direction;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        Rb.velocity = Vector3.zero;
    }

    private void FixedUpdate(){
        Rb.velocity = Direction * Speed;
    }

    void Update(){
        
    }

    public void SetDirection(Vector2 direction){
        Direction = direction;
    }

    public void DestroyStick(){
        Destroy(gameObject);
    }
}
