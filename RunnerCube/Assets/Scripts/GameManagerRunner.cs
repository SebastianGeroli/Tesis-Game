﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerRunner : MonoBehaviour
{
    /*################################  Variables  ##################################*/
    public bool isPc = false;
    public int etapa = 1;
    public Score score;
    public bool gameOver = false;
    public Invoker invoker;
    public Player6x6 player;
    //private float timerObs = 0;
    /*################################  Metodos  ##################################*/
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
       // invoker.WallsInstanciate();
        invoker.ObstacleInstanciate();
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
            //timerObs += Time.deltaTime;
            
           invoker.ObstacleLauncher();
            if (player.GetVidas() <= 0)
            {
                score.CheckScore();
                player.SetVidas(5);
                player.VidasUpdate();
            }
        }
        
    }
    private void FixedUpdate()
    {
        SpeedUp();
    }

    //SpeedUp
    public void SpeedUp() {
        if (!isPc)
        {
            if (score.GetScore() > 1000 && etapa == 1)
            {
                for (int i = 0; i < invoker.obstacles.Length; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.4f));
                    etapa = 2;
                }
            }
            if (score.GetScore() > 2000 && etapa == 2)
            {
                for (int i = 0; i < invoker.obstacles.Length; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.5f));
                    etapa = 3;
                }
            }
            if (score.GetScore() > 3000 && etapa == 3)
            {
                for (int i = 0; i < invoker.obstacles.Length; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.6f));
                    etapa = 3;
                }
            }
        }
        else {
            if (score.GetScore() > 1000 && etapa == 1)
            {
                for (int i = 0; i < invoker.obstacles.Length; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.4f));
                    invoker.SetlaunchTime(1.8f);
                    score.Multiplier = 1.2f;
                    etapa = 2;
                }
            }
            if (score.GetScore() > 2000 && etapa == 2)
            {
                for (int i = 0; i < invoker.obstacles.Length; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.5f));
                    invoker.SetlaunchTime(1.6f);
                    score.Multiplier = 1.4f;
                    etapa = 3;
                }
            }
            if (score.GetScore() > 3000 && etapa == 3)
            {
                for (int i = 0; i < invoker.obstacles.Length; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.6f));
                    invoker.SetlaunchTime(1.4f);
                    score.Multiplier = 1.6f;
                    etapa = 4;
                }
            }
            if (score.GetScore() > 4000 && etapa == 4)
            {
                for (int i = 0; i < invoker.obstacles.Length; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.7f));
                    invoker.SetlaunchTime(1.2f);
                    score.Multiplier = 1.8f;
                    etapa = 5;
                }
            }
            if (score.GetScore() > 5000 && etapa == 5)
            {
                for (int i = 0; i < invoker.obstacles.Length; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.8f));
                    invoker.SetlaunchTime(1f);
                    score.Multiplier = 2f;
                    etapa = 6;
                }
            }
            if (score.GetScore() > 6000 && etapa == 6)
            {
                for (int i = 0; i < invoker.obstacles.Length; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.9f));
                    invoker.SetlaunchTime(0.8f);
                    score.Multiplier = 3f;
                    etapa = 6;
                }
            }
        }
       

    }
}

