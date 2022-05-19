using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : PARENTenemy
{
    private float vspd = 100;

    private float gravity = .25f;   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _cam.transform.position.x + _camWidth / 2)
        {
            Activate = true;
        }
        
        if (!Activate) return;
        
        transform.Translate(new Vector2(-75,vspd) *Time.deltaTime);
        vspd = vspd - gravity;
    }

    new void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.CompareTag("Tile"))
        {
            vspd = 100;
        }
    } 
}
