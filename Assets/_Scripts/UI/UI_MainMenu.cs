using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_MainMenu : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void Comecar()
    {
        gm.ChangeState(GameManager.GameState.START);
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
    }
}
