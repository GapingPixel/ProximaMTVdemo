using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerController : MonoBehaviour
{
    public GameObject Bullet;
    private float timeRemaining = 0;
    bool timerIsRunning = false;
    bool secondBulletShot = false;
    private Vector2 bulletVector = Vector2.zero;
    private Rigidbody2D rb;
    private Camera cam;
    private float camHeight;
    private float camWidth;
    private Vector2 _moveDirection = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        /*float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        _moveDirection = new Vector2(moveX, moveY).normalized;
        rb.velocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);*/
        float moveSpeed = 50f;
        
        bool rightKey = Input.GetKey("d");
        bool leftKey  = Input.GetKey("a");
        bool upKey = Input.GetKey("w");
        bool downKey  = Input.GetKey("s");
        bool buttonA = Input.GetKeyDown("p");
        bool buttonB = Input.GetKeyDown("l");
        bool buttonX = Input.GetKeyDown("o");
        bool buttonY = Input.GetKeyDown("k");
        if (rightKey)
        {
            //rb.velocity = (Vector2.right * Time.deltaTime * moveSpeed);
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
            //transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        } 
        if (leftKey)
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
        if (upKey)
        {
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
        } 
        if (downKey)
        {
            transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
        }
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, cam.transform.position.x-(camWidth/2)+25, cam.transform.position.x+(camWidth/2)-25), Mathf.Clamp(transform.position.y, -190f, -35f));
        
        //Fire
        if (buttonA && !timerIsRunning)
        {
            Instantiate(Bullet, new Vector2(transform.position.x+23, transform.position.y), Quaternion.identity);
            timerIsRunning = true;
            timeRemaining = 0.25f;
            bulletVector = new Vector2(transform.position.x+23, transform.position.y);
        }

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            if (timeRemaining <= 0.2f && !secondBulletShot)
            {
                Instantiate(Bullet,bulletVector, Quaternion.identity);
                secondBulletShot = true;
            }
            else if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerIsRunning = false;
                secondBulletShot = false;
            }
        }

    }

    private void FixedUpdated()
    {
        
        

        
    }

    
}
