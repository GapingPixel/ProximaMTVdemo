using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class scrBullet : MonoBehaviour
{
    private int dmg = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,5f);
    }

    // Update is called once per frame
    void Update()
    {
        int speed = 400;
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
}
