using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerRunner:MonoBehaviour
{
    /*################################  Variables  ##################################*/

    public float speeTexture = 1f;
    public Light topLight, bottomLight, leftLight, rightLight;
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
    [SerializeField]
    private float score2 = 1000f;
    //public Player6x6 player;

    /*###############################################################################
                                   Metodos
    #################################################################################*/
    //GameOver Changer || este metodo cambia el gameover
    public void GameOverChanger()
    {
        if (gameOver == false && player.GetVidas() <= 0)
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
       // invoker.ObstacleGenerator();
    }

    //Update
    public void Update()
    {
        CameraChanger();
        if (pause)
        {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
        GameOverChanger();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        if (!gameOver)
        {
            //timerObs += Time.deltaTime;
            LightsChanger();
           invoker.ObstacleLauncher();
            if (player.GetVidas() <= 0)
            {
                score.CheckScore();
                player.SetVidas(5);
                player.VidasUpdate();
            }
        }
        
    }
    private void LateUpdate()
    {
        SpeedUp();
    }
    //SpeedUp Mejorado
    public void SpeedUp() {
      
        if ( isPc )
        {
            if ( score.GetScore() > score2)
            {
                for ( int i = 0 ; i < invoker.obstacles.Count ; i++ )
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(obs.GetVelocity() - new Vector3(0 , 0 , 0.15f));
                }
                speeTexture = Mathf.Lerp(speeTexture , speeTexture + 0.2f , Time.time * 2f);
                invoker.SetlaunchTime(invoker.GetlaunchTime() - 0.1f);
                etapa++;
            }
        }
        else
        {
            if ( score.GetScore() > score2 && etapa < 8 )
            {
                for ( int i = 0 ; i < invoker.obstacles.Count ; i++ )
                {
                    Obstacles obs = invoker.obstacles[i].GetComponent<Obstacles>();
                    obs.SetVelocity(obs.GetVelocity() - new Vector3(0 , 0 , 0.15f));
                }
                speeTexture = Mathf.Lerp(speeTexture , speeTexture + 0.2f , Time.time * 2f);
                invoker.SetlaunchTime(invoker.GetlaunchTime() - 0.1f);
                etapa++;
            }
        }
        if ( score.GetScore() > score2 )
        {
            score.SetMultipier(score.GetMulplier() * 1.5f);
            score2 = score.GetScore() * 2f;
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

    //Light changer
    public void LightsChanger() {
        switch ( player.GravityPos )
        {
            case 0:
                bottomLight.enabled = true;
                topLight.enabled = false;
                leftLight.enabled = false;
                rightLight.enabled = false;
                break;

            case 1:
                bottomLight.enabled = false;
                topLight.enabled = true;
                leftLight.enabled = false;
                rightLight.enabled = false;
                break;

            case 2:
                bottomLight.enabled = false;
                topLight.enabled = false;
                leftLight.enabled = false;
                rightLight.enabled = true;
                break;

            case 3:
                bottomLight.enabled = false;
                topLight.enabled = false;
                leftLight.enabled = true;
                rightLight.enabled = false;
                break;
        }
    }

    
}
