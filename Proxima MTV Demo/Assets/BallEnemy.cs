using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnemy : PARENTenemy
{
    private float vspeed = 50;
    private Transform player;
    private float time;
    private bool atPlayerHeight;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _cam.transform.position.x + _camWidth / 2)
        {
            Activate = true;
        }

        if (!Activate) return;

        

        if (transform.position.y >= player.position.y && time+0.4f < Time.time)
        {
            atPlayerHeight = true;
        }

        if (atPlayerHeight)
        {
            float hspeed = -120;
            transform.Translate(new Vector2(hspeed, 0) * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector2(0, vspeed) * Time.deltaTime);
        }

        
    }
}