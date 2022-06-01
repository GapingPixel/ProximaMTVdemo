using System;
using UnityEngine;

public class EnemyZigZag : PARENTenemy
{
    private float _vspeed;
    private float _ystart;
    private bool _goingUp = true;
    
    // Start is called before the first frame update
    void Start()
    {
        _ystart = transform.position.y;
        Hp = 4;
    }
    
    void Update()
    {
        if (transform.position.x < _cam.transform.position.x + _camWidth / 2)
        {
            Activate = true;
        }
        if (!Activate) return;
        float hspeed = -75f;
        transform.Translate(new Vector2(hspeed,_vspeed) *Time.deltaTime);
    }
    
    
    void FixedUpdate()//50 Ticks
    {
        if (!Activate) return;

        float maxvspd = 60;
        float _spd = 6f;
        switch (_goingUp)
        {
            case true:
                _vspeed+= _spd;
                if (transform.position.y > _ystart+7)
                {
                    _goingUp = false;
                } 
                break;
            
            case false:
                _vspeed-= _spd;
                if (transform.position.y < _ystart-7)
                {
                    _goingUp = true;
                }
                break;
        }
        _vspeed = Math.Clamp(_vspeed, -maxvspd, maxvspd);
    }

}
