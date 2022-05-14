using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class scrPlayerController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Explosion;
    private float _timeRemaining;
    private bool _timerIsRunning;
    private bool _secondBulletShot;
    private Vector2 _bulletVector = Vector2.zero;
    private GameManager _manager;
    private Camera _cam;
    private float _camHeight;
    private float _camWidth;
    /*
    private Rigidbody2D _rb;
    private Vector2 _moveDirection = Vector2.zero;
    */
    // Start is called before the first frame update
    void Start()
    {
        //_rb = gameObject.GetComponent<Rigidbody2D>();
        _cam = Camera.main;
        _camHeight = 2f * _cam.orthographicSize;
        _camWidth = _camHeight * _cam.aspect;
        _manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        GameManager.GameOver = false;
        GameManager.Reload = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        _moveDirection = new Vector2(moveX, moveY).normalized;
        rb.velocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);*/
        float moveSpeed = 70f;
        
        bool rightKey = Input.GetKey("d");
        bool leftKey  = Input.GetKey("a");
        bool upKey = Input.GetKey("w");
        bool downKey  = Input.GetKey("s");
        //var buttonA = Convert.ToBoolean (Mathf.Max(Convert.ToSingle (Input.GetKeyDown("p")), Convert.ToSingle(Input.GetMouseButtonDown(0)) ));
        var buttonA = Input.GetKeyDown(KeyCode.P) || Input.GetMouseButtonDown(0);
        var buttonB = Convert.ToBoolean (Mathf.Max(Convert.ToSingle (Input.GetKeyDown("l")), Convert.ToSingle(Input.GetMouseButtonDown(1)) ));
        //if (buttonB) SceneManager.LoadScene("MainMenu"); 
        
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
        var rot = gameObject.transform.localRotation.eulerAngles; //get the angles
        if (upKey)
        {
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
            
            //rot.Set(40f, 0f, 0f); 
            /*if (transform.rotation.x < 40)
            {
                rot.Set(transform.rotation.x + 1, 0f, 0f); //set the angles
            }
            else
            {
                rot.Set(transform.rotation.x, 0f, 0f); //set the angles
            }*/
        }
        if (downKey)
        {
            transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
            //rot.Set(163f, 0f, 0f); 
        }
        if (!upKey && !downKey)
        {
            //rot.Set(0f, 0f, 0f); 
        }
        //gameObject.transform.localRotation = Quaternion.Euler(rot); //update the transform
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, _cam.transform.position.x-(_camWidth/2)+25, _cam.transform.position.x+(_camWidth/2)-25), Mathf.Clamp(transform.position.y, -218f, -12f));
        
        //Fire
        if (buttonA && !_timerIsRunning)
        {
            _bulletVector = new Vector2(transform.position.x+8, transform.position.y);
            Instantiate(Bullet, _bulletVector, Quaternion.identity);
            _timerIsRunning = true;
            _timeRemaining = 0.20f;
            
        }

        if (_timerIsRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            if (_timeRemaining <= 0.16f && !_secondBulletShot)
            {
                Instantiate(Bullet,_bulletVector, Quaternion.identity);
                _secondBulletShot = true;
            }
            else if (_timeRemaining <= 0)
            {
                _timeRemaining = 0;
                _timerIsRunning = false;
                _secondBulletShot = false;
            }
        }

    }
    
    
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Tile"))
        {
            Destroy(gameObject);
        } else if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (!GameManager.GameOver)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            GameManager.Lives--;
            print(GameManager.Lives);
        }

    }
    
}
