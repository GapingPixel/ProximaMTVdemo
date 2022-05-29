using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class scrAnimExplosionEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private float _delay;
    public GameObject PowerUp;
 
    // Use this for initialization
    void Start () {
        Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + _delay); 
    }
    
    void OnDestroy()
    {
        if (Time.frameCount == 0 || inEditor.EditorApplicationQuit || GameManager.GameOver) {
            return;
        }
        if (GameManager.Reload) return;
        //Drop Item
        if (Random.Range(0, 20) == 1)
        {
            Instantiate(PowerUp,transform.position,Quaternion.identity);
        }

    }
}
