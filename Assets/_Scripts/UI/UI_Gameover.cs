﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Gameover : MonoBehaviour
{
    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void Menu()
    {
        gm.ChangeState(GameManager.GameState.MENU);
        gm.Reset();
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
}