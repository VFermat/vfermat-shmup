using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Game : MonoBehaviour
{
    GameManager gm;
    Text[] texts;

    private void Start()
    {
        gm = GameManager.GetInstance();
        texts = GetComponentsInChildren<Text>();
    }
    public void Update()
    {
        foreach (Text text in texts) {
            if (text.name == "PlayerLife") {
                text.text = $"\tVidas: {gm.playerLifes}";
            } else if (text.name == "PlayerScore") {
                text.text = $"Pontos: {gm.score}\t";
            } else if (text.name == "HighScore") {
                text.text = $"HighScore: {gm.highScores[0]}";
            }
        }
    }

}
