using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrAnimExplosionEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private float _delay;
 
    // Use this for initialization
    void Start () {
        Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + _delay); 
    }
    
    void OnDestroy()
    {
        //Drop Item
        GameManager.GameOver = true;

    }
}
