using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVerticalSpawner : PARENTenemy
{
    public GameObject ballEn;
    public Sprite DamagedSprite;
    private SpriteRenderer spriteRenderer;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        Hp = 10;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _cam.transform.position.x + _camWidth / 2)
        {
            Activate = true;
        }
        
        if (!Activate) return;

        
        if (time+1f < Time.time)
        {
            Instantiate( ballEn,new Vector2(transform.position.x, transform.position.y+8f) ,  Quaternion.identity);
            time = Time.time;
        }

        if (Hp <= 5)
        {
            spriteRenderer.sprite = DamagedSprite;
        }
        
    }
}
