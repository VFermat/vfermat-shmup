using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Rank : MonoBehaviour
{
    GameManager gm;
    Text rank;

    private void Start()
    {
        gm = GameManager.GetInstance();
        rank = GetComponent<Text>();
        BuildRank();
    }

    public void BuildRank() {
        string msg = "Melhores Jogadores\n\n";
        for (int i = 0; i<10; i++) {
            msg += $"{gm.highScorePlayers[i]}: {gm.highScores[i]}\n";
        }
        rank.text = msg;
    }
}
