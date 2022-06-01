using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : PARENTenemy
{
    private SpriteRenderer _spriteRenderer;
    public Sprite[ ] Sprite;
    public GameObject Projectile;

    private float _startY;
    private float _yTravelDistance = 55;
    private float _speed = 40;
    private bool _moveUp = true;
    private bool _intro = true;
    //private Camera _cam;
    private GameManager _manager;
    private int _count;
    // Start is called before the first frame update
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _cam = Camera.main;
        _manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        _startY = transform.position.y;
    }

    /*private void OnDestroy()
    {
        _manager.RestartGame();
    }*/

    private void FixedUpdate()
    {
        if (_cam.transform.position.x < 3775) return;
        
        if (_intro) return;
        _count++;
        if (_count != 50) return;
        _count = 0;
        Instantiate(Projectile, new Vector2(transform.position.x+7, transform.position.y+18), Quaternion.identity);
        Instantiate(Projectile, new Vector2(transform.position.x-9, transform.position.y+6), Quaternion.identity);
        Instantiate(Projectile, new Vector2(transform.position.x-9, transform.position.y-6), Quaternion.identity);
        Instantiate(Projectile, new Vector2(transform.position.x+7, transform.position.y-18), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        if (_cam.transform.position.x < 3775) return;
        
        _cam.GetComponent<scrCameraMovement>().CameraMove = false;
        MoveBackground.moveBackground = false;
        if (_intro)
        {
            if (transform.position.x > _cam.GetComponent<Transform>().transform.position.x+75)
            {
                transform.Translate(Vector2.left * 30 * Time.deltaTime);
                
            }
            else
            {
                _intro = false;
            }
            return;
        }
        //-111 is middle of the screen
        if (Hp <= 10)
        {
            //_spriteRenderer.sprite = Sprite[1];
            switch (_moveUp)
            {
                case true:
                    transform.Translate(Vector2.up * _speed * Time.deltaTime);
                    if (transform.position.y > _startY + _yTravelDistance)
                    {
                        _moveUp = false;
                    }
                    break;

                case false:
                    transform.Translate(Vector2.down * _speed * Time.deltaTime);
                    if (transform.position.y < _startY - +_yTravelDistance)
                    {
                        _moveUp = true;
                    }
                    break;
            }
        }
        else
        {
            switch (_moveUp)
            {
                case true:
                    transform.Translate(Vector2.up * _speed * Time.deltaTime);
                    if (transform.position.y > _startY + _yTravelDistance)
                    {
                        _moveUp = false;
                    }
                    break;

                case false:
                    transform.Translate(Vector2.down * _speed * Time.deltaTime);
                    if (transform.position.y < _startY)
                    {
                        _moveUp = true;
                    }
                    break;

            }
        }

    }
    
}
