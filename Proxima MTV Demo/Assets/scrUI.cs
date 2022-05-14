using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scrUI : MonoBehaviour
{
    private Camera _cam;

    public Sprite[] Lives;
    private GameManager _manager;
    SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    
    void Awake()
    {
        _cam = Camera.main;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(_cam.transform.position.x-130, _cam.transform.position.y-80);
        _spriteRenderer.sprite = Lives[GameManager.Lives];
        //print(_manager.Lives); 
    }
}
