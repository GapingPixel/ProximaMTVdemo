using System.Collections;
using System.Collections.Generic;
 #if UNITY_EDITOR
 using UnityEditor;
 using UnityEditor.SceneManagement;
 #endif
using UnityEngine;
using UnityEngine.SceneManagement;


public class AnimExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    private float _delay = 2;
    private GameManager _manager;
    // Use this for initialization
    void Start () {
        Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + _delay);
        _manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
    }

    void Update()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void OnDestroy()
    {
        if (GameManager.Lives >= 0 && !GameManager.GameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameManager.Reload = true;
        }

        /*foreach (InstantiateOnDestroy i in indObjectsOfType<InstantiateOnDestroy>())
            Destroy(i);*/
        //EditorSceneManager.OpenScene("Level1");
    }
}
