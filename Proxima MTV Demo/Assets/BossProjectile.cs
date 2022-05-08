using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public readonly int Dmg = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {
        int speed = 400;
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
    
    
}