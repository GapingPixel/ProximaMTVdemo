using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [HideInInspector]public Vector2 BulletVector = Vector2.zero;

    private float _speed = 65;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(BulletVector*Time.deltaTime *_speed);
    }
}
