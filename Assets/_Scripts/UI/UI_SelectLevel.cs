using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_SelectLevel : MonoBehaviour
{
    GameManager gm;

    private void OnEnable()
    {
        Debug.Log("Debugginnggg");
        gm = GameManager.GetInstance();
    }
    public void Easy()
    {
        gm.ChangeLevel(GameManager.GameLevel.EASY);
        gm.ChangeState(GameManager.GameState.GAME);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        // LoadGame();
    }

    public void Medium()
    {
        gm.ChangeLevel(GameManager.GameLevel.MEDIUM);
        LoadGame();
    }
    
    public void Hard()
    {
        gm.ChangeLevel(GameManager.GameLevel.HARD);
        LoadGame();
    }

    private void LoadGame() {
        gm.ChangeState(GameManager.GameState.GAME);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
