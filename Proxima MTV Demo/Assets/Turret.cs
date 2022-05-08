using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : PARENTenemy
{
    
    private SpriteRenderer _spriteRenderer;
    public Sprite[ ] Sprite;
    private Transform _player;
    public GameObject Bullet;
    private Vector2 _bulletVector = Vector2.zero;

    private int _count;
    // Start is called before the first frame update
    void Start()
    {
        if (_player == null) _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    new void Update()
    {
        if (transform.position.x < _cam.transform.position.x + _camWidth / 2)
        {
            Activate = true;
        }
        if (!Activate) return;
        
        if (_player == null) return;
        
        if (transform.position.y < _player.transform.position.y)//Turret is Below
        {
            //transform.localRotation =  Quaternion.Euler(0,0,0);
            transform.localRotation = Quaternion.Euler(0, transform.position.x < _player.transform.position.x ? 0 : 180, 0);
        }
        else //Turret is Above
        {
            transform.localRotation = Quaternion.Euler(180, transform.position.x > _player.transform.position.x ? 180 : 0, 0);
        }
        
        if (Mathf.Abs(transform.position.y-_player.transform.position.y)  <= 15)
        {
            _spriteRenderer.sprite = Sprite[2];
        }
        else
        {
            _spriteRenderer.sprite = Mathf.Abs(transform.position.x - _player.transform.position.x) <= 15 ? Sprite[1] : Sprite[0];
        }
    }

    private void FixedUpdate()
    {
        if (!Activate) return;
        
        if (_player == null) return;
        if (_count == 100)
        {
            _bulletVector = new Vector2(_player.transform.position.x-transform.position.x, _player.transform.position.y-transform.position.y).normalized;
            GameObject enemyInstance  = (GameObject)Instantiate(Bullet, transform.position, Quaternion.identity);
            enemyInstance.GetComponent<EnemyProjectile>().BulletVector = _bulletVector;
            _count = 0;
        }
        _count++;
    }
}
