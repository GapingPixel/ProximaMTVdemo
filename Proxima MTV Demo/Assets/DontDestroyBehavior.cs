using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1 || SceneManager.GetActiveScene().name == "MainMenu" )
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void OnLevelWasLoaded(int level) {
        if (level == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void DestroyF()
    {
        Destroy(gameObject);
    }
}
