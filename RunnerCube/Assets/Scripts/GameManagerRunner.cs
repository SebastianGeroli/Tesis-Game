using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerRunner : MonoBehaviour
{
    /*###############################################################################
                                   Variables
    #################################################################################*/
    public bool gameOver = false;
    public Invoker invoker;
    public Player6x6 player;

    /*###############################################################################
                                   Metodos
    #################################################################################*/
    //GameOver Changer || este metodo cambia el gameover
    public void GameOverChanger()
    {
        if (gameOver == false && player.vidas == 0)
        {
            gameOver = true;
            SceneManager.LoadScene(2);
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
        GameOverChanger();
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
