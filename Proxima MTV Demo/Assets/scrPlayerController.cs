using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerController : MonoBehaviour
{
    private Rigidbody2D rb; 
    Vector2 _moveDirection = Vector2.zero;

    private float moveSpeed = 50f;
    
    private bool rightKey;
    private bool leftKey;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

       
        
        print(Input.GetAxisRaw("Horizontal")); 
        
        
        
        _moveDirection = new Vector2(moveX, moveY).normalized;
        rb.velocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);
        
        //transform.position = new Vector2(transform.position.x, transform.position.y);
        /*
        rightKey= Input.GetKey("d");
        leftKey = Input.GetKey("a");
        if (rightKey)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        } else if (leftKey)
        {
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }*/
    }

    private void FixedUpdated()
    {
        
        
        //_moveDirection = new Vector2(moveX, moveY).normalized;
        //rb.velocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);

        
        
        //bool swing = Input.GetKeyDown("x");
        bool buttonA = Input.GetKeyDown("p");
        bool buttonB = Input.GetKeyDown("l");
        bool buttonX = Input.GetKeyDown("o");
        bool buttonY = Input.GetKeyDown("k");
        
        
        
        //transform.position = new Vector2(Mathf.Clamp(transform.position.x, 58f, 2127f), Mathf.Clamp(transform.position.y, -780f, -100f));
       

        
    }

    
}
