using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossDestroyAnim : MonoBehaviour
{
    // Start is called before the first frame update
    private float _delay =.5f;
    private GameManager _manager;

    private DontDestroyOnLoad soundtrack;
    // Use this for initialization
    void Start () {
        Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + _delay); 
        _manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        soundtrack = GameObject.FindGameObjectWithTag("Music").GetComponent<DontDestroyOnLoad>();
    }

    void OnDestroy()
    {
        GameManager.RestartGame();
        soundtrack.Destroyf();

    }
}
