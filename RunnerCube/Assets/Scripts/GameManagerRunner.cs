using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerRunner : MonoBehaviour
{
    /*################################  Variables  ##################################*/
    public int etapa = 1;
    public Score score;
    public bool gameOver = false;
    public Invoker invoker;
    public Player6x6 player;
    private float timerObs = 0;
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
            SpeedUp();
            timerObs += Time.deltaTime;
            
           invoker.ObstacleLauncher();
            if (player.GetVidas() <= 0)
            {
                score.CheckScore();
                player.SetVidas(5);
                player.VidasUpdate();
            }
        }
        
    }

    //SpeedUp
    public void SpeedUp() {
        if (score.GetScore() > 1000 && etapa == 1) {
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
}

