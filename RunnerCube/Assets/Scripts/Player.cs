using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private float timer;
    public int GravityPos = 0;
    bool isJumping;
    Transform obstacle;
    //Reset esta funcion devuelve el cubo a su posicion anterior luego de 2 segundos inicial luego de 2 segundos
    public void ResetPos()
    {
        switch (GravityPos) {
            case 0:
                transform.Translate(0, -4, 0);
                break;
            case 1:
                transform.Translate(0, 4, 0);
                break;
            case 2:
                transform.Translate(4.5f, 0, 0);
                break;
            case 3:
                transform.Translate(-4.5f, 0, 0);
                break;
        }
        isJumping = false;
    }
    //Swipe Up
    public void SwipeUp() {
      
        switch (GravityPos) {
            //Gravedad  arriba -> abajo
            case 0:
                if (!isJumping && transform.position.y != 8)
                {
                    transform.Translate(0, 4, 0);
                    isJumping = true;
                }
                else if (isJumping && transform.position.y != 8) {
                    transform.Translate(0, 4, 0);
                    isJumping = false;
                    GravityPos = 1;
                }
                break;
            case 1:
                if (isJumping) {
                    transform.Translate(0, 4, 0);
                    isJumping = false;
                }
                break;
            case 2:
                if (isJumping && transform.position.y == 7)
                {
                    transform.Translate(0, 1, 0);
                    isJumping = false;
                    GravityPos = 1;
                }
                else if (transform.position.y != 7)
                {
                    transform.Translate(0, 3, 0);
                }
                else {
                    transform.Translate(-1.5f, 1, 0);
                    GravityPos = 1;
                }

                break;
            case 3:
                if (isJumping && transform.position.y == 7)
                {
                    transform.Translate(0, 1, 0);
                    isJumping = false;
                    GravityPos = 1;
                }
                else if (transform.position.y != 7)
                {
                    transform.Translate(0, 3, 0);
                }
                else {
                    transform.Translate(1.5f, 1, 0);
                    GravityPos = 1;
                }

                break;
        }
    }
    //Swipe Down
    public void SwipeDown()
    {
        switch (GravityPos)
        {
            case 0:
                if (isJumping) {
                    transform.Translate(0, -4, 0);
                    isJumping = false;
                }
                break;
            case 1:
                if (!isJumping && transform.position.y != 0)
                {

                    transform.Translate(0, -4, 0);
                    isJumping = true;
                }
                else if (isJumping && transform.position.y != 0) {
                    transform.Translate(0, -4, 0);
                    isJumping = false;
                    GravityPos = 0;
                }
                break;
            case 2:
                if (isJumping && transform.position.y == 1)
                {
                    transform.Translate(0f, -1, 0);
                    isJumping = false;
                    GravityPos = 0;
                }
                else if (transform.position.y > 1)
                {
                    transform.Translate(0, -3, 0);
                }else
                {
                    transform.Translate(-1.5f, -1, 0);
                    GravityPos = 0;
                }
                break;
            case 3:
                if (isJumping && transform.position.y == 1)
                {
                    transform.Translate(0f, -1, 0);
                    isJumping = false;
                    GravityPos = 0;
                }
                else if (transform.position.y > 1)
                {
                    transform.Translate(0, -3, 0);
                }else {
                    transform.Translate(1.5f, -1, 0);
                    GravityPos = 0;
                }
                break;
        }
    }
    //Swipe Left
    public void SwipeLeft() {

        switch (GravityPos) {
            case 0:
                if (isJumping && transform.position.x == -3)
                {
                    transform.Translate(-1.5f, 0, 0);
                    isJumping = false;
                    GravityPos = 3;
                }
                else if (transform.position.x != -3)
                {
                    transform.Translate(-3, 0, 0);
                }else {
                    transform.Translate(-1.5f, 1, 0);
                    GravityPos = 3;
                }
                break;

            case 1:
                if (isJumping && transform.position.x == -3)
                {
                    transform.Translate(-1.5f, 0, 0);
                    isJumping = false;
                    GravityPos = 3;
                }
                else if (transform.position.x != -3)
                {
                    transform.Translate(-3, 0, 0);
                }
                else
                {
                    transform.Translate(-1.5f, -1, 0);
                    GravityPos = 3;
                }
                break;

            case 2:
                if (!isJumping && transform.position.x == 4.5f)
                {

                    transform.Translate(-4.5f, 0, 0);
                    isJumping = true;
                }
                else if (isJumping && transform.position.x != -4.5f) {
                    transform.Translate(-4.5f, 0, 0);
                    isJumping = false;
                    GravityPos = 3;
                }
                
                break;
            case 3:
                if (isJumping) {
                    transform.Translate(-4.5f, 0, 0);
                    isJumping = false;
                }
                break;
        }
    }
    //Swipe Right
    public void SwipeRight() {
        switch (GravityPos)
        {
            case 0:
                if (isJumping && transform.position.x == 3)
                {
                    transform.Translate(1.5f, 0, 0);
                    isJumping = false;
                    GravityPos = 2;

                }
                
                else if (transform.position.x < 3)
                {
                    transform.Translate(3, 0, 0);
                }
                else
                {
                    transform.Translate(1.5f, 1, 0);
                    GravityPos = 2;
                }
                break;
            case 1:
                if (isJumping && transform.position.x == 3)
                {
                    transform.Translate(1.5f, 0, 0);
                    isJumping = false;
                    GravityPos = 2;

                }
                else if (transform.position.x < 3)
                {
                    transform.Translate(3, 0, 0);
                }
                else
                {
                    transform.Translate(1.5f, -1, 0);
                    GravityPos = 2;
                }
                break;

            case 2:
                if (isJumping)
                {
                    transform.Translate(4.5f, 0, 0);
                    isJumping = false;
                }
                break;
            case 3:
                if (!isJumping && transform.position.x == -4.5f)
                {

                    transform.Translate(4.5f, 0, 0);
                    isJumping = true;
                }
                else if (isJumping && transform.position.x != 4.5f) {
                    transform.Translate(4.5f, 0, 0);
                    isJumping = false;
                    GravityPos = 2;
                }
                break;
        }
            
    }
    //Teleport FUNCION EN PRUEBA  
    public void DobleJump()
    {
        float posY = transform.position.y;
        int i = (int)posY;
        switch (i)
        {
            case 0:
                transform.Translate(0, 4, 0);
                break;
            case 4:
                transform.Translate(0, -4, 0);
                break;


        }
    }
    //Mueve Al player en Z  NOTA NO ES NECESARIO ROMPE EL CODIGO
    public void MovePlayer()
    {
        transform.Translate(0, 0, 0.25f);
    }
    //Update Con detector de keypressed

    void Update()
    {// Debugs
        //Debug.Log("Timer: " + timer);
        //Debug.Log("Esta saltando: "+ isJumping);
        //Debug.Log("Gravedad: "+GravityPos);
        //Fin Debugs
        timer += Time.deltaTime;
        if (isJumping && timer > 2) {
            ResetPos();
        }
        if (!isJumping) {
            timer = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.W)) {
            SwipeUp();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SwipeLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SwipeRight();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
           SwipeDown();
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    DobleJump();
        //}

    }
    private void OnTriggerEnter(Collider other)
    {
        obstacle = other.gameObject.GetComponent<Transform>();
        if (obstacle.tag == "Objeto") {
            Debug.Log("Choco");
        }
    }
}
