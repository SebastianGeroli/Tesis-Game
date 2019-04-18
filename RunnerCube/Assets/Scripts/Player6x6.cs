﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player6x6 : MonoBehaviour
{
    /*################################  Variables  ##################################*/
    private float timer;
    public int GravityPos = 0;
    bool isJumping;
    Transform obstacle;
    private Vector3 up = new Vector3(0,2,0);
    private Vector3 down = new Vector3(0, -2, 0);
    private Vector3 right = new Vector3(2, 0, 0);
    private Vector3 left = new Vector3(-2, 0, 0);
    private Vector3 shortRight = new Vector3(0.5f, 0, 0);
    private Vector3 shortLeft = new Vector3(-0.5f, 0, 0);
    private Vector3 LongRight = new Vector3(2.5f, 0, 0);
    private Vector3 LongLeft = new Vector3(-2.5f, 0, 0);

    /*################################  Metodos  ##################################*/
    //Swipe Up
    public void SwipeUp()
    {
        if (Input.GetKeyDown(KeyCode.W) || SwipeDetector.Instance.IsSwiping(SwipeDirection.Up))
        {
            switch (GravityPos)
            {
                //Gravedad  arriba -> abajo
                case 0:
                    if (!isJumping && transform.position.y !=2 )
                    {
                        transform.Translate(up);
                        isJumping = true;
                    }
                    else if (isJumping && transform.position.y != 4)
                    {
                        transform.Translate(up);
                        isJumping = false;
                        GravityPos = 1;
                    }
                    break;
                //Gravedad abajo -> arriba
                case 1:
                    if (isJumping)
                    {
                        transform.Translate(up);
                        isJumping = false;
                    }
                    break;
                //Gravedad derecha -> izquierda
                case 2:
                    if (isJumping && transform.position.y == 4f)
                    {
                        //transform.Translate(-0.5f, 0, 0);
                        isJumping = false;
                        GravityPos = 1;
                    }
                    else if (transform.position.y != 4)
                    {
                        transform.Translate(up);
                    }
                    else if(!isJumping && transform.position.y == 4f)
                    {
                        transform.Translate(shortLeft);
                        GravityPos = 1;
                    }

                    break;
                //Gravedad izquierda -> derecha
                case 3:
                    if (isJumping && transform.position.y == 4f)
                    {
                        //transform.Translate(0, 0.5f, 0);
                        isJumping = false;
                        GravityPos = 1;
                    }
                    else if (transform.position.y != 4f)
                    {
                        transform.Translate(up);
                    }
                    else if(!isJumping && transform.position.y == 4f)
                    {
                        transform.Translate(shortRight);
                        GravityPos = 1;
                    }

                    break;
            }
        }
    }
    //Swipe Down
    public void SwipeDown()
    {
        if (Input.GetKeyDown(KeyCode.S) || SwipeDetector.Instance.IsSwiping(SwipeDirection.Down))
        {

            switch (GravityPos)
            {
                //Gravedad abajo -> arriba
                case 0:
                    if (isJumping)
                    {
                        transform.Translate(down);
                        isJumping = false;
                    }
                    break;
                //Gravedad arriba -> abajo
                case 1:
                    if (!isJumping && transform.position.y != 0)
                    {

                        transform.Translate(down);
                        isJumping = true;
                    }
                    else if (isJumping && transform.position.y != 0)
                    {
                        transform.Translate(down);
                        isJumping = false;
                        GravityPos = 0;
                    }
                    break;
                //Gravedad derecha -> izquierda
                case 2:
                    if (isJumping && transform.position.y == 0)
                    {
                        //transform.Translate(shortLeft);
                        isJumping = false;
                        GravityPos = 0;
                    }
                    else if (!isJumping && transform.position.y == 0)
                    {
                        transform.Translate(shortLeft);
                        GravityPos = 0;
                    }
                    else
                    {
                        transform.Translate(down);
                    }
                    break;
                //Gravedad izquierda -> derecha
                case 3:
                    if (isJumping && transform.position.y ==0)
                    {
                        //transform.Translate(shortRight);
                        isJumping = false;
                        GravityPos = 0;
                    }
                    else if (!isJumping && transform.position.y == 0)
                    {
                        transform.Translate(shortRight);
                        GravityPos = 0;
                    }
                    else
                    {
                        transform.Translate(down);
                    }
                    break;
            }
        }

    }
    //Swipe Left
    public void SwipeLeft()
    {
        if (Input.GetKeyDown(KeyCode.A) || SwipeDetector.Instance.IsSwiping(SwipeDirection.Left))
        {
            switch (GravityPos)
            {
                //Gravedad abajo -> arriba
                case 0:
                    if (isJumping && transform.position.x == -2)
                    {
                        transform.Translate(shortLeft);
                        isJumping = false;
                        GravityPos = 3;
                    }
                    else if (!isJumping && transform.position.x == -2) 
                    {
                        transform.Translate(shortLeft);
                        GravityPos = 3;
                        
                    }
                    else if (transform.position.x != -2)
                    {
                        transform.Translate(left);
                    }
                    break;
                //Gravedad arriba -> abajo
                case 1:
                    if (isJumping && transform.position.x == -2)
                    {
                        transform.Translate(shortLeft);
                        isJumping = false;
                        GravityPos = 3;
                    }
                    else if (!isJumping && transform.position.x == -2)
                    {
                        transform.Translate(shortLeft);
                        GravityPos = 3;

                    }
                    else if (transform.position.x != -2)
                    {
                        transform.Translate(left);
                    }
                    break;
                //Gravedad derecha -> izquierda
                case 2:
                    if (!isJumping && transform.position.x == 2.5f)
                    {
                        transform.Translate(LongLeft);
                        isJumping = true;
                    }
                    else if (isJumping && transform.position.x != -2.5f)
                    {
                        transform.Translate(LongLeft);
                        isJumping = false;
                        GravityPos = 3;
                    }

                    break;
                //Gravedad izquierda -> derecha
                case 3:
                    if (isJumping)
                    {
                        transform.Translate(LongLeft);
                        isJumping = false;
                    }
                    break;
            }
        }

    }
    //Swipe Right
    public void SwipeRight()
    {
        if (Input.GetKeyDown(KeyCode.D) || SwipeDetector.Instance.IsSwiping(SwipeDirection.Right))
        {
            switch (GravityPos)
            {
                //Gravedad abajo -> arriba
                case 0:
                    if (isJumping && transform.position.x == 2)
                    {
                        transform.Translate(shortRight);
                        isJumping = false;
                        GravityPos = 2;

                    }

                    else if (!isJumping && transform.position.x == 2) 
                    {
                        transform.Translate(shortRight);
                        GravityPos = 2;
                        
                    }
                    else if(transform.position.x != 2)
                    {
                        transform.Translate(right);
                    }
                    break;
                //Gravedad arriba -> abajo
                case 1:
                    if (isJumping && transform.position.x == 2)
                    {
                        transform.Translate(shortRight);
                        isJumping = false;
                        GravityPos = 2;

                    }

                    else if (!isJumping && transform.position.x == 2)
                    {
                        transform.Translate(shortRight);
                        GravityPos = 2;

                    }
                    else if (transform.position.x != 2)
                    {
                        transform.Translate(right);
                    }
                    break;
                //Gravedad derecha -> izquierda
                case 2:
                    if (isJumping)
                    {
                        transform.Translate(LongRight);
                        isJumping = false;
                    }
                    break;
                //Gravedad izquierda -> derecha
                case 3:
                    if (!isJumping && transform.position.x == -2.5f)
                    {

                        transform.Translate(LongRight);
                        isJumping = true;
                    }
                    else if (isJumping && transform.position.x != 2.5f)
                    {
                        transform.Translate(LongRight);
                        isJumping = false;
                        GravityPos = 2;
                    }
                    break;
            }
        }
    }
    //Update
    void Update()
    {   // Debugs
        //Debug.Log("Timer: " + timer);
        //Debug.Log("Esta saltando: "+ isJumping);
        //Debug.Log("Gravedad: "+GravityPos);
        //Fin Debugs
        SwipeUp();
        SwipeRight();
        SwipeLeft();
        SwipeDown();

    }
    //Trigger  || detecta si choca contra los obstaculos
    private void OnTriggerEnter(Collider other)
    {
        obstacle = other.gameObject.GetComponent<Transform>();
        if (obstacle.tag == "Objeto")
        {
            Debug.Log("Choco");
        }
    }
}
