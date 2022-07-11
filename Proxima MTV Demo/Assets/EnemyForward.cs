using UnityEngine;

public class EnemyForward : PARENTenemy
{
    
    private int _count;
    private float _speed = 70;
    private float _timer = 0;
    private int _stage = 1;
    private Vector2 _angularVector;
    
    [HideInInspector]public enum Patterns
    {
        Down, 
        Up
    };

    [HideInInspector]public Patterns Pattern;
    
    // Start is called before the first frame update
    void Start()
    {
        _angularVector = (Vector2)(Quaternion.Euler(0,0,180) * (Vector2.right * _speed)); 
    }
    
    public void Update()
    {
        if ((transform.position.x < _cam.transform.position.x + _camWidth / 2) && !Activate)
        {
            Activate = true;
            _timer = Time.time;
        }
        
        if (!Activate) return;
        
        switch (Pattern)
        {
            case Patterns.Down:
            if (Time.time >= _timer+1.5 && _stage == 1)
            {
                _speed = 150;
                _angularVector = (Vector2) (Quaternion.Euler(0, 0, 50) * (Vector2.right * _speed ));
                _stage = 2;
            }
            
            if (Time.time >= _timer+2 && _stage == 2)
            {
                _speed = 240;
                _angularVector =  (Vector2) (Quaternion.Euler(0, 0, 0) * (Vector2.right * _speed ));
                _stage = 3;
                //count = 100;
            } 
            
            break;
            
            case Patterns.Up:
            if (Time.time >= _timer+1.5 && _stage == 1)
            {
                _speed = 150;
                _angularVector = (Vector2) (Quaternion.Euler(0, 0, 320) * (Vector2.right * _speed ));
                _stage = 2;
            }
            
            if (Time.time >= _timer+2 && _stage == 2)
            {
                _speed = 240;
                _angularVector =  (Vector2) (Quaternion.Euler(0, 0, 0) * (Vector2.right * _speed ));
                _stage = 3;
                //count = 100;
            } 
            break;    
                
        }


        transform.Translate(_angularVector * Time.deltaTime);
    }
    
    private void FixedUpdate()//50 Ticks
    {
        if (!Activate) return;
        
        /*
        _count++;
        switch (Pattern)
        {
            case Patterns.Down:
            if (_count == 75)
            {
                _angularVector = (Vector2) (Quaternion.Euler(0, 0, 67) * (Vector2.right * _speed));
                _speed = 0.3f;
            }
            else if (_count == 100)
            {
                _angularVector = (Vector2) (Quaternion.Euler(0, 0, 0) * (Vector2.right * _speed));
                //count = 100;
            }
            break;
            
            case Patterns.Up:
                if (_count == 75)
                {
                    _angularVector = (Vector2) (Quaternion.Euler(0, 0, 301) * (Vector2.right * _speed));
                    _speed = 0.3f;
                }
                else if (_count == 100)
                {
                    _angularVector = (Vector2) (Quaternion.Euler(0, 0, 0) * (Vector2.right * _speed));
                    //count = 100;
                }
                break;
        }*/
    }
    
    

}
