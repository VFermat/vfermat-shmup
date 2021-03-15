using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_DefineName : MonoBehaviour
{
    GameManager gm;
    InputField playerName;

    private void Start()
    {
        gm = GameManager.GetInstance();
        playerName = gameObject.GetComponentInChildren<InputField>();
    }

    public void LoadGame() {
        gm.playerName = playerName.text;
        gm.ChangeState(GameManager.GameState.GAME);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
