using UnityEngine;

public class EnemyDiagonal : PARENTenemy
{
    private SpriteRenderer _spriteRenderer;
    public Sprite[] Sprite;
    private Transform _player;

    private int speed = 60;
    private Vector2 _angularVector;
    // Start is called before the first frame update
    void Start()
    {
        if (_spriteRenderer == null) _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (_player == null) _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (transform.position.x < _cam.transform.position.x + _camWidth / 2)
        {
            Activate = true;
        }
        if (!Activate) return;
        
        if (_player == null) return;
        
        if ( Mathf.Abs(transform.position.y-_player.transform.position.y) < 8)//Horizontal
        {
            _angularVector = (Vector2)(Quaternion.Euler(0,0,180) * (Vector2.right*speed* Time.deltaTime));
            _spriteRenderer.sprite = Sprite[0];
        } 
        else if (transform.position.y < _player.transform.position.y)//Go Up
        {
            _angularVector = (Vector2)(Quaternion.Euler(0,0,135) * (Vector2.right*speed* Time.deltaTime));
            _spriteRenderer.sprite = Sprite[1];
        } 
        else if (transform.position.y > _player.transform.position.y)//Go Down
        {
            _angularVector = (Vector2)(Quaternion.Euler(0,0,225) * (Vector2.right*speed* Time.deltaTime));
            _spriteRenderer.sprite = Sprite[2];
        }
        else
        {   //When No Player
            _angularVector = (Vector2)(Quaternion.Euler(0,0,180) * (Vector2.right*speed* Time.deltaTime));
            _spriteRenderer.sprite = Sprite[0];
        }
      
        transform.Translate(_angularVector);
    }
}
