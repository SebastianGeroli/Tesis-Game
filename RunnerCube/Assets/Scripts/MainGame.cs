﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerRunner : MonoBehaviour {
    public bool gameOver = false;
    public Invoker invoker;
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

    //Start
    public void Start()
    {
        invoker.ObstacleGenerator();
    }
    //Update
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameOverChanger();
        }
        if (!gameOver)
        {
            invoker.WallGenerator();
            invoker.ObstacleLauncher();
            //Debug.Log("Playing");
        }
        else {
            //Debug.Log("End");
        }
    }
}
