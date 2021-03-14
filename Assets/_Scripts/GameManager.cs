using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    public int playerLifes;
    public int score;
    public int highScore;
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
        highScore = 0;
        gameState = GameState.GAME;
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void Reset()
    {
        if (score > highScore) highScore = score;
        playerLifes = 10;
        score = 0;
    }
}
