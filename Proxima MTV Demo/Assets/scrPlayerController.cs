using System;
using Random = UnityEngine.Random;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEditor;
using UnityEngine.InputSystem;


//using UnityEngine.InputSystem.Controls;



public class scrPlayerController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Missile;
    public GameObject Explosion;
    
    [NonSerialized]public static int Hp = 3;
    private float _timeRemaining;
    private bool _timerIsRunning;
    private bool _secondBulletShot;
    private Vector2 _bulletVector = Vector2.zero;
    private GameManager _manager;
    private Camera _cam;
    private float _camHeight;
    private float _camWidth;

    
    public InputAction ShootAction;
    private Vector2 movement;
    private bool shootInput;
    private bool missileInput;
    private int hurtTimer;
    public static PlayerInput controls;

    [NonSerialized]public bool HasMissile = true;
    //private ButtonControl 
    void SetUpActions()
    {
        controls = new PlayerInput();
        controls.Enable();
    }
    void Awake()
    {
        SetUpActions();
        switch (GameManager.Checkpoint)
        {
            case 1:
                transform.position = new Vector3(791, transform.position.y, transform.position.z);
                break;

            case 2:
                transform.position = new Vector3(2085, transform.position.y, transform.position.z);
                break;

            case 3:
                transform.position = new Vector3(200, transform.position.y, transform.position.z);
                break;
            
        }

    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    
    void Start()
    {
        //_rb = gameObject.GetComponent<Rigidbody2D>();
        _cam = Camera.main;
        _camHeight = 2f * _cam.orthographicSize;
        _camWidth = _camHeight * _cam.aspect;
        _manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        GameManager.GameOver = false;
        GameManager.Reload = false;
        Hp = 3;
    }

    
    // Update is called once per frame
    void Update()
    {
        shootInput = Mathf.Abs(controls.Player.Shoot.ReadValue<float>()) > 0;
        missileInput = Mathf.Abs(controls.Player.Missile.ReadValue<float>()) > 0;
        /*float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        _moveDirection = new Vector2(moveX, moveY).normalized;
        rb.velocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);*/
        float moveSpeed = 70f;
        
        //bool rightKey = Input.GetKey("d") || Input.GetKey(KeyCode.Joystick1Button8);
        //bool leftKey  = Input.GetKey("a") || Input.GetKey(KeyCode.Joystick1Button7);
        //bool upKey = Input.GetKey("w") || Input.GetKey(KeyCode.Joystick1Button5);
        //bool downKey  = Input.GetKey("s") || Input.GetKey(KeyCode.Joystick1Button6);
        //var buttonA = Convert.ToBoolean (Mathf.Max(Convert.ToSingle (Input.GetKeyDown("p")), Convert.ToSingle(Input.GetMouseButtonDown(0)) ));
        //var buttonA = Input.GetKeyDown(KeyCode.P) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton16);
        //var buttonB = Convert.ToBoolean (Mathf.Max(Convert.ToSingle (Input.GetKeyDown("l")), Convert.ToSingle(Input.GetMouseButtonDown(1)),  Convert.ToSingle(Input.GetKeyDown(KeyCode.Joystick1Button17))));
        //if (buttonB) SceneManager.LoadScene("MainMenu"); 
        
        //bool buttonX = Input.GetKeyDown("o") || Input.GetKeyDown(KeyCode.Joystick1Button18);
        //bool buttonY = Input.GetKeyDown("k") || Input.GetKeyDown(KeyCode.Joystick1Button19);

        
        if (movement.x != 0 || movement.y != 0)
        {
            /*if (movement.x != 0 && movement.y != 0)
            {
                if (movement.x > 0)
                {
                    movement.x = 0.707f;
                }
                else
                {
                    movement.x = -0.707f;
                }
                
                if (movement.y > 0)
                {
                    movement.y = 0.707f;
                }
                else
                {
                    movement.y = -0.707f;
                }
            }
            else
            {
                
            }*/
            movement = movement.normalized;
            transform.Translate(movement * Time.deltaTime * moveSpeed);
        }

        
        var rot = gameObject.transform.localRotation.eulerAngles; //get the angles
        
        
        //gameObject.transform.localRotation = Quaternion.Euler(rot); //update the transform
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, _cam.transform.position.x-(_camWidth/2)+25, _cam.transform.position.x+(_camWidth/2)-25), Mathf.Clamp(transform.position.y, -218f, -12f));
        
        //Fire
        if (shootInput && !_timerIsRunning)
        {
            _bulletVector = new Vector2(transform.position.x+8, transform.position.y);
            Instantiate(Bullet, _bulletVector, Quaternion.identity);
            int chance = Random.Range(0, 3);
            if (HasMissile && chance == 0)
            {
                var missileVector = new Vector2(transform.position.x, transform.position.y-5); 
                Instantiate(Missile, missileVector, Quaternion.identity);
            }
            _timerIsRunning = true;
            _timeRemaining = 0.20f;
            SoundController.PlaySound("PlayerShoot");
        }

        if (missileInput)
        {
            
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
        if (hurtTimer > 0) return;
        var maxHurtTime = 50;
        if (other.gameObject.CompareTag("Enemy"))
        {
            Hp--;
            CheckHp();
            Destroy(other.gameObject);
            hurtTimer = maxHurtTime;
            if (Hp > 0)
            {
                SoundController.PlaySound("PlayerHit");
            }
        }
        else if (other.gameObject.CompareTag("Tile"))
        {
            Hp=0;
            CheckHp();
        }
        else if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            Hp--;
            CheckHp();
            Destroy(other.gameObject);
            hurtTimer = maxHurtTime;
            if (Hp > 0)
            {
                SoundController.PlaySound("PlayerHit");
            }
        } 
        else if (other.gameObject.CompareTag("PowerUp"))
        {
             HasMissile = true;
             SoundController.PlaySound("PickUp");
             Destroy(other.gameObject);
        }
    }

    private void CheckHp()
    {
        if (Hp <= 0)
        {
            Destroy(gameObject);
            SoundController.PlaySound("PlayerDeath");
        }
    }
    
    private void OnDestroy()
    {
        if (Time.frameCount == 0 || inEditor.EditorApplicationQuit) {
            return;
        }
        
        if (!GameManager.GameOver)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            GameManager.Lives--;
            
            print(GameManager.Lives);
        }

    }

    private void FixedUpdate()
    {
        if (_cam.GetComponent<scrCameraMovement>().CameraMove)
        {
            transform.position = new Vector3(transform.position.x+_cam.GetComponent<scrCameraMovement>().CameraSpeed, transform.position.y, transform.position.z);
        }
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (hurtTimer > 0)
        {
            hurtTimer--;
            spriteRenderer.enabled = hurtTimer % 2 ==0;
            /*Color color = (1,0,0,1);
            Shader.SetGlobalColor("_color",color);*/
        }
    }
}
