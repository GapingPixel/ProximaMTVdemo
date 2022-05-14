using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private scrPlayerController _player;
    [HideInInspector]public static int Lives = 2;
    [HideInInspector]public static bool GameOver = false;
    [HideInInspector]public static bool Reload = false;
    public enum GameState
    {
        Play,
        Lose
    }

    private GameState _state = GameState.Play; 
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null) // If there is no instance already
        {
            DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
            Instance = this;
        } else if(Instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }
        if (_player == null) _player = GameObject.FindGameObjectWithTag("Player").GetComponent<scrPlayerController>();
    }

    void Start()
    {
        UpdateGameState(GameState.Play);
    }

    void Update()
    {
        if (Lives < 0)
        {
            RestartGame();
        }
        
        var buttonB = Convert.ToBoolean (Mathf.Max(Convert.ToSingle (Input.GetKeyDown("l")), Convert.ToSingle(Input.GetMouseButtonDown(1)) ));
        if (buttonB) SceneManager.LoadScene("MainMenu"); 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
        Lives = 2;
        GameOver = true;
    }
    
    public void UpdateGameState(GameState newState)
    {
        
    }

    

    
}
