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

    private void FixedUpdate(){
        Rb.velocity = Direction * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDirection(Vector2 direction){
        Direction = direction;
    }

    public void DestroyStick(){
        Destroy(gameObject);
    }
}
