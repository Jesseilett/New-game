using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject losePanel;
    public GameObject winPanel;
    public string gameSceneName; 

    public GameObject[] m_Enemies;
    public int enemyCount; 

    void start()
    {
        enemyCount = m_Enemies.length; 
    }

    void update()
    {
        if (enemyCount <= 0)
        {
            WinGame; 
        }
    }

    private float m_gameTime = 0;
    public float GameTime { get { return m_gameTime; } }

    public enum GameState
    {
        Start,
        Playing,
        GameOver
    };

    private GameState m_GameState;
    public GameState State { get { return m_GameState; } } 

    private void Awake() 
    { 
        m_GameState = GameState.Start; 
    }

    private void Start()
    {
        for (int i = 0; i < m_Enemies.Length; i++) 
        {
            m_Enemies[i].SetActive(false); 
        }
    }

    void Update()
    {
        switch (m_GameState)
        {
           case GameState.Start:
                if (Input.GetKeyUp(KeyCode.Return) == true)
                {
                    m_GameState = GameState.Playing;

                    for (int i = 0; i < m_Enemies.Length; i++)
                    {
                        m_Enemies[i].SetActive(true);   
                    }
                }
                break;
                case GameState.Playing:
                bool isGameOver = false;

                m_gameTime += Time.deltaTime;
                int seconds = Mathf.RoundToInt(m_gameTime);

                if (OneEnemyLeft() == true)
                {
                    isGameOver = true; 
                }
                else if (IsPlayerDead() == true)
                {
                    isGameOver = true; 
                }

                if (isGameOver == true)
                {
                    m_GameState = GameState.GameOver; 
                }
                break;
            case GameState.GameOver:
                if (Input.GetKeyUp(KeyCode.Return) == true)
                {
                    m_gameTime = 0;
                    m_GameState = GameState.Playing;

                    for (int i = 0; i < m_Enemies.Length; i++)
                    {
                        m_Enemies[i].SetActive(true); 
                    }
                }
                break; 
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit(); 
        }
    }

    private bool OneEnemyLeft()
    {
        int numEnemiesLeft = 0;

        for (int i = 0; i < m_Enemies.Length; i++)
        {
            if (m_Enemies[i].activeSelf == true)
            {
                numEnemiesLeft++; 
            }
        }
        return numEnemiesLeft <= 1; 
    }

    private bool IsPlayerDead()
    {
        for (int i = 0; i < m_Enemies.Length; i++)
        {
            if (m_Enemies[i].activeSelf == false)
            {
                if (m_Enemies[i].tag == "Player")
                    return true;
            }
        }
        return false; 
    }

    public void LoseGame()
    {
        losePanel.SetActive(true); 
    }

    public void WinGame()
    {
        winPanel.SetActive(true); 
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(gameSceneName); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
} 




    