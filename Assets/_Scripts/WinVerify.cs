using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinVerify : MonoBehaviour
{
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");
        if (objs.Length <= 0) {
            gm.ChangeState(GameManager.GameState.ENDGAME);
            SceneManager.LoadScene("GameoverScene", LoadSceneMode.Single);
        }
    }
}
