﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerRunner : MonoBehaviour
{
    /*###############################################################################
                                   Variables
    #################################################################################*/
    public bool gameOver = false;
    public Invoker invoker;

    /*###############################################################################
                                   Metodos
    #################################################################################*/
    //GameOver Changer || este metodo cambia el gameover
    public void GameOverChanger()
    {
        if (gameOver == false)
        {
            gameOver = true;
        }
        else
        {
            gameOver = false;
        }
    }
    //Pause || Este Metodo pone pausa
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
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
            Pause();
        }
        if (!gameOver)
        {

            invoker.WallGenerator();
            invoker.ObstacleLauncher();

        }
        else
        {

        }
    }
}