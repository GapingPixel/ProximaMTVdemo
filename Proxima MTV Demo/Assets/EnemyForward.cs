using UnityEngine;

public class EnemyForward : PARENTenemy
{
    
    private int _count;
    private int _speed = 5;
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
        _angularVector = (Vector2)(Quaternion.Euler(0,0,180) * (Vector2.right*_speed* Time.fixedDeltaTime)); 
    }
    
    public void Update()
    {
        if (transform.position.x < _cam.transform.position.x + _camWidth / 2)
        {
            Activate = true;
        }
        
        if (!Activate) return;
        
        if (transform.position.x < _cam.transform.position.x + _camWidth / 2)
        {
            Activate = true;
        }
        
        transform.Translate(_angularVector);
    }
    
    private void FixedUpdate()//50 Ticks
    {
        if (!Activate) return;
        
        _count++;
        switch (Pattern)
        {
            case Patterns.Down:
            if (_count == 50)
            {
                _angularVector = (Vector2) (Quaternion.Euler(0, 0, 67) * (Vector2.right * _speed * Time.fixedDeltaTime));
                _speed = 10;
            }
            else if (_count == 75)
            {
                _angularVector = (Vector2) (Quaternion.Euler(0, 0, 0) * (Vector2.right * _speed * Time.fixedDeltaTime));
                //count = 100;
            }
            break;
            
            case Patterns.Up:
                if (_count == 50)
                {
                    _angularVector = (Vector2) (Quaternion.Euler(0, 0, 301) * (Vector2.right * _speed * Time.fixedDeltaTime));
                    _speed = 10;
                }
                else if (_count == 75)
                {
                    _angularVector = (Vector2) (Quaternion.Euler(0, 0, 0) * (Vector2.right * _speed * Time.fixedDeltaTime));
                    //count = 100;
                }
                break;
        }
    }
    
    

}
