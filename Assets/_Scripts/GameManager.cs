using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{

    public string playerName;
    public int playerLifes;
    public int score;
    public int[] highScores = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    public string[] highScorePlayers = new string[10] {"", "", "", "", "", "", "", "", "", ""};
    private static GameManager _instance;

    // Game State
    public enum GameState { MENU, START, GAME, PAUSE, ENDGAME };
    public GameState gameState { get; private set; }
    public GameState lastGameState { get; private set; }


    public void ChangeState(GameState nextState)
    {
        if (nextState == GameState.GAME) Reset();
        lastGameState = gameState;
        gameState = nextState;
    }

    // Game Level
    public enum GameLevel { EASY, MEDIUM, HARD};
    public GameLevel gameLevel { get; private set; }
    public void ChangeLevel(GameLevel level) {
        gameLevel = level;
    }

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }

    private GameManager()
    {
        playerLifes = 10;
        score = 0;
        playerName = "Jane Doe";
        gameState = GameState.MENU;
        SceneManager.LoadScene("RankScene", LoadSceneMode.Single);
    }

    public void Reset()
    {
        UpdateHighScore();
        playerName = "Jane Doe";
        playerLifes = 10;
        score = 0;
    }

    public void UpdateHighScore() {
        int i;
        for (i = 0; i <= 9; i++) {
            if (score > highScores[i]) break;
        }
        Debug.Log(1);
        for (int j = 9; j >= i; j--) {
            highScorePlayers[j] = highScorePlayers[j-1];
            highScores[j] = highScores[j-1];
        }
        highScorePlayers[i-1] = playerName;
        highScores[i-1] = score;
    }
} 
