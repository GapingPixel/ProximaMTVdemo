using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ScoreManager ScoreScript;
    public static bool LevelCompleted = false; 
    [NonSerialized]public static int Lives = 2;
    [NonSerialized]public static int Checkpoint = 0;
    [NonSerialized]public static bool GameOver = false;
    [NonSerialized]public static bool Reload = false;
    [NonSerialized]public static bool GameOverScreen = false;
    [NonSerialized]public static float WaitForRestart;

    
    private scrPlayerController _player;
    
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
    void Update()
    {
        
        if (Lives < 0)
        {
            PopGameOverScreen();
            
        }

        if (LevelCompleted )
        {
            PopGameOverScreen();
            
        }
        
    }

    public void PopGameOverScreen()
    {
        if (!GameOverScreen)
        {
            foreach (var obj in GameObject.FindGameObjectsWithTag("PlayerUI"))
            {
                obj.SetActive(false);
            }
            WaitForRestart = Time.time + 3f;
            GameOverScreen = true;
            if (ScoreScript == null) ScoreScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<ScoreManager>();
            foreach (var gos in ScoreScript.GameOverObjs)
            {
                gos.SetActive(true);
            }
        }
        else
        {
            if (WaitForRestart <= Time.time)
            {
                RestartGame();
            }
        }
    }
    
    public static void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
        Lives = 2;
        GameOver = true;
        Checkpoint = 0;
        WaitForRestart = 0;
        GameOverScreen = false;
        LevelCompleted = false;
        ScoreManager.Score = 0;
        scrPlayerController.FinishLevel = false;

    }
    
    
    

    

    
}
