using System;
using UnityEngine;

public class EnemyFastShip : PARENTenemy
{
    private float _vspeed;
    private float _ystart;
    private bool _goingUp = true;
    
    // Start is called before the first frame update
    void Start()
    {
        _ystart = transform.position.y;
        Hp = 1;
    }
    
    void Update()
    {
        if (transform.position.x < _cam.transform.position.x + _camWidth / 2)
        {
            Activate = true;
        }
        if (!Activate) return;
        float hspeed = -250f;
        transform.Translate(new Vector2(hspeed,_vspeed) *Time.deltaTime);
    }
    
    
    void FixedUpdate()//50 Ticks
    {
        if (!Activate) return;

        float maxvspd = 30;
        float _spd = 10f;
        float _yBound = 2;
        switch (_goingUp)
        {
            case true:
                _vspeed+= _spd;
                if (transform.position.y > _ystart+_yBound)
                {
                    _goingUp = false;
                    transform.position = new Vector3 (transform.position.x,_ystart+_yBound, transform.position.z);
                } 
                break;
            
            case false:
                _vspeed-= _spd;
                if (transform.position.y < _ystart-_yBound)
                {
                    _goingUp = true;
                    transform.position = new Vector3 (transform.position.x,_ystart-_yBound, transform.position.z);
                }
                break;
        }
        _vspeed = Math.Clamp(_vspeed, -maxvspd, maxvspd);
    }

}