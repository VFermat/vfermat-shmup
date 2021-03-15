using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Start : MonoBehaviour
{
    GameManager gm;

    private void OnEnable()
    {
        Debug.Log("Debugginnggg");
        gm = GameManager.GetInstance();
    }

    public void LoadGame() {
        gm.ChangeState(GameManager.GameState.GAME);
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
