using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Gameover : MonoBehaviour
{
    private GameManager gm;
    public Text text;

    private void Start()
    {
        gm = GameManager.GetInstance();
        gm.Reset();
        text = GetComponentsInChildren<Text>()[0];
        if (gm.playerLifes > 0) {
            text.text = "Parabéns, você venceu!";
        }
    }

    public void Menu()
    {
        gm.ChangeState(GameManager.GameState.MENU);
        gm.Reset();
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
    public void Rank()
    {
        gm.ChangeState(GameManager.GameState.MENU);
        gm.Reset();
        SceneManager.LoadScene("RankScene", LoadSceneMode.Single);
    }
}
