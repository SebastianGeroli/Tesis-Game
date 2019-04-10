using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour {
    public bool gameOver = false;
    public void GameOverChanger()
    {
        if (gameOver == false)
        {
            gameOver = true;
        }
        else {
            gameOver = false;
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameOverChanger();
        }
        if (gameOver == false)
        {
            //Debug.Log("Playing");
        }
        else {
            //Debug.Log("End");
        }
    }
}
