using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossDestroyAnim : MonoBehaviour
{
    // Start is called before the first frame update
    private float _delay;
    private GameManager _manager;
    private int _count = 20; 
    // Use this for initialization
    void Start () {
        Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + _delay); 
        _manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void FixedUpdate()
    {
        _count--;
        if (_count == 0)
        {
            //_manager.RestartGame();
            
        }
    }
    
    void OnDestroy()
    {
        //Drop Item

    }
}