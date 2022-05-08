using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrAnimExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    private float _delay;
    private GameManager _manager;
    // Use this for initialization
    void Start () {
        Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + _delay); 
        _manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        
    } 
    

    void OnDestroy()
    {
        if (_manager.Lives >= 0 && !_manager.GameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        /*foreach (InstantiateOnDestroy i in indObjectsOfType<InstantiateOnDestroy>())
            Destroy(i);*/
        //EditorSceneManager.OpenScene("Level1");
    }
}
