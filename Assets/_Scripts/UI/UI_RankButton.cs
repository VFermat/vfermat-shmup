using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_RankButton : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}
