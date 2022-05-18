using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public readonly int Dmg = 2;
    private Camera _cam;
    private float _camHeight;
    private float _camWidth;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject,0.5f);
        _cam = Camera.main;
        _camHeight = 2f * _cam.orthographicSize;
        _camWidth = _camHeight * _cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        int speed = 100;
        transform.Translate(new Vector2(1f,-1) * Time.deltaTime * speed);
        

        if (transform.position.x > _cam.transform.position.x + _camWidth / 2)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tile"))
        {
            Destroy(gameObject);
        }
    }


}
