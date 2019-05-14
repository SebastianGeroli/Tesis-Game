﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerRunner : MonoBehaviour
{
<<<<<<< HEAD
    /*################################  Variables  ##################################*/
    public Camera camera1;
    public Camera camera2;
    public bool useSecondCamera = false;
    public bool pause = false;
    public bool isPc = false;
    public int etapa = 1;
    public Score score;
    public bool gameOver = false;
    public Invoker invoker;
    public Player player;
    /*################################  Metodos  ##################################*/
=======
    /*###############################################################################
                                   Variables
    #################################################################################*/
    public bool gameOver = false;
    public Invoker invoker;
    public Player6x6 player;

    /*###############################################################################
                                   Metodos
    #################################################################################*/
>>>>>>> UIDevelop
    //GameOver Changer || este metodo cambia el gameover
    public void GameOverChanger()
    {
        if (gameOver == false)
        {
            gameOver = true;
            Debug.Log("Deberia cargar la escena");
        }
        else
        {
            gameOver = false;
        }
    }

    //Pause || Este Metodo pone pausa
    public void Pause()
    {
        if (pause)
        {
            pause = false;
        }
        else {
            pause = true;
        }
    }

    //Start
    public void Start()
    {
       // invoker.WallsInstanciate();
        invoker.ObstacleInstanciate();
        invoker.ObstacleGenerator();
    }

    //Update
    public void Update()
    {
<<<<<<< HEAD
        CameraChanger();
        if (pause)
        {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
=======
        GameOverChanger();
>>>>>>> UIDevelop
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (!gameOver)
        {
<<<<<<< HEAD
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
                for (int i = 0; i < invoker.obstacles.Count; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.4f));
                    invoker.SetlaunchTime(1.8f);
                    score.SetMultipier(1.2f);
                    etapa = 2;
                }
            }
            if (score.GetScore() > 3000 && etapa == 2)
            {
                for (int i = 0; i < invoker.obstacles.Count; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.5f));
                    invoker.SetlaunchTime(1.6f);
                    score.SetMultipier(1.4f);
                    etapa = 3;
                }
            }
            if (score.GetScore() > 6000 && etapa == 3)
            {
                for (int i = 0; i < invoker.obstacles.Count; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.6f));
                    invoker.SetlaunchTime(1.4f);
                    score.SetMultipier(1.6f);
                    etapa = 4;
                }
            }
            if (score.GetScore() > 12000 && etapa == 4)
            {
                for (int i = 0; i < invoker.obstacles.Count; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.7f));
                    invoker.SetlaunchTime(1.2f);
                    score.SetMultipier(1.8f);
                    etapa = 5;
                }
            }
            if (score.GetScore() > 24000 && etapa == 5)
            {
                for (int i = 0; i < invoker.obstacles.Count; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.8f));
                    invoker.SetlaunchTime(1f);
                    score.SetMultipier(2f);
                    etapa = 6;
                }
            }
        }
        else {
            if (score.GetScore() > 1000 && etapa == 1)
            {
                for (int i = 0; i < invoker.obstacles.Count; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.4f));
                    invoker.SetlaunchTime(1.8f);
                    score.SetMultipier(1.2f);
                    etapa = 2;
                }
            }
            if (score.GetScore() > 3000 && etapa == 2)
            {
                for (int i = 0; i < invoker.obstacles.Count; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.5f));
                    invoker.SetlaunchTime(1.6f);
                    score.SetMultipier(1.4f);
                    etapa = 3;
                }
            }
            if (score.GetScore() > 6000 && etapa == 3)
            {
                for (int i = 0; i < invoker.obstacles.Count; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.6f));
                    invoker.SetlaunchTime(1.4f);
                    score.SetMultipier(1.6f);
                    etapa = 4;
                }
            }
            if (score.GetScore() > 12000 && etapa == 4)
            {
                for (int i = 0; i < invoker.obstacles.Count; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.7f));
                    invoker.SetlaunchTime(1.2f);
                    score.SetMultipier(1.8f);
                    etapa = 5;
                }
            }
            if (score.GetScore() > 24000 && etapa == 5)
            {
                for (int i = 0; i < invoker.obstacles.Count; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.8f));
                    invoker.SetlaunchTime(1f);
                    score.SetMultipier(2f);
                    etapa = 6;
                }
            }
            if (score.GetScore() > 48000 && etapa == 6)
            {
                for (int i = 0; i < invoker.obstacles.Count; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -0.9f));
                    invoker.SetlaunchTime(0.8f);
                    score.SetMultipier(3f);
                    etapa = 7;
                }
            }
            if (score.GetScore() > 96000 && etapa == 7)
            {
                for (int i = 0; i < invoker.obstacles.Count; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -1.1f));
                    invoker.SetlaunchTime(0.7f);
                    score.SetMultipier(5f);
                    etapa = 8;
                }
            }
            if (score.GetScore() > 150000 && etapa == 8 )
            {
                for (int i = 0; i < invoker.obstacles.Count; i++)
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(new Vector3(0, 0, -1.3f));
                    invoker.SetlaunchTime(0.6f);
                    score.SetMultipier(10f);
                    etapa = 8;
                }
            }
        }
       

    }

    //Camera Changer
    public void CameraChanger() {
        if (useSecondCamera)
        {
            camera1.enabled = false;
            camera2.enabled = true;
        }
        else {
            camera1.enabled = true;
            camera2.enabled = false;
        }
    }
=======

            invoker.WallGenerator();
            invoker.ObstacleLauncher();

        }
        else
        {

        }
        
    }
    
>>>>>>> UIDevelop
}
