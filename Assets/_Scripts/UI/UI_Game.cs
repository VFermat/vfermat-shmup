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
        Debug.Log("Teste Start");
        gm = GameManager.GetInstance();
        texts = GetComponentsInChildren<Text>();
        Debug.Log(texts[0].name);
    }
    public void Update()
    {
        foreach (Text text in texts) {
            Debug.Log("Teste");
            if (text.name == "PlayerLife") {
                text.text = $"\tVidas: {gm.playerLifes}";
            } else if (text.name == "PlayerScore") {
                text.text = $"Pontos: {gm.score}\t";
            }
        }
    }

}
