using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player6x6 : MonoBehaviour
{
    /*################################  Variables  ##################################*/
    public Text vidasText;
    private int vidas = 5;
    private float timer;
    public int GravityPos = 0;
    bool isJumping;
    Transform obstacle;
    private Vector3 up1 = new Vector3(0,2.5f,0);
    private Vector3 up2 = new Vector3(0, 2.5f, 0);
    private Vector3 down1 = new Vector3(0, -2.5f, 0);
    private Vector3 down2 = new Vector3(0, -2.5f, 0);
    private Vector3 upWall = new Vector3(0, 2, 0);
    private Vector3 downWall = new Vector3(0, -2, 0);
    private Vector3 right = new Vector3(2, 0, 0);
    private Vector3 left = new Vector3(-2, 0, 0);
    private Vector3 shortRight = new Vector3(0.5f, 0, 0);
    private Vector3 shortLeft = new Vector3(-0.5f, 0, 0);
    private Vector3 shortUp = new Vector3(0, 0.5f, 0);
    private Vector3 shortDown = new Vector3(0, -0.5f, 0);
    private Vector3 LongRight = new Vector3(2.5f, 0, 0);
    private Vector3 LongLeft = new Vector3(-2.5f, 0, 0);
    /*################################  Getters && Setters  ##################################*/
    public int GetVidas()
    {
        return vidas;
    }
    public void SetVidas(int a)
    {
        vidas = a;
    }
    /*################################  Metodos  ##################################*/
    //Update Vidas in Text
    public void VidasUpdate() {
        vidasText.text = GetVidas().ToString();
    }
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
                        transform.Translate(up1);
                        isJumping = true;
                    }
                    else if (isJumping && transform.position.y != 4)
                    {
                        transform.Translate(up2);
                        isJumping = false;
                        GravityPos = 1;
                    }
                    break;
                //Gravedad abajo -> arriba
                case 1:
                    if (isJumping)
                    {
                        transform.Translate(up2);
                        isJumping = false;
                    }
                    break;
                //Gravedad derecha -> izquierda
                case 2:
                    if (isJumping && transform.position.y == 4.5f)
                    {
                        transform.Translate(shortUp);
                        isJumping = false;
                        GravityPos = 1;
                    }
                    else if (transform.position.y != 4.5f)
                    {
                        transform.Translate(upWall);
                    }
                    else if(!isJumping && transform.position.y == 4.5f)
                    {
                        transform.Translate(shortLeft+shortUp);
                        GravityPos = 1;
                    }

                    break;
                //Gravedad izquierda -> derecha
                case 3:
                    if (isJumping && transform.position.y == 4.5f)
                    {
                        transform.Translate(shortUp);
                        isJumping = false;
                        GravityPos = 1;
                    }
                    else if (transform.position.y != 4.5f)
                    {
                        transform.Translate(upWall);
                    }
                    else if(!isJumping && transform.position.y == 4.5f)
                    {
                        transform.Translate(shortRight+shortUp);
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
                        transform.Translate(down1);
                        isJumping = false;
                    }
                    break;
                //Gravedad arriba -> abajo
                case 1:
                    if (!isJumping && transform.position.y != 0)
                    {

                        transform.Translate(down2);
                        isJumping = true;
                    }
                    else if (isJumping && transform.position.y != 0)
                    {
                        transform.Translate(down1);
                        isJumping = false;
                        GravityPos = 0;
                    }
                    break;
                //Gravedad derecha -> izquierda
                case 2:
                    if (isJumping && transform.position.y == 0.5f)
                    {
                        transform.Translate(shortDown);
                        isJumping = false;
                        GravityPos = 0;
                    }
                    else if (!isJumping && transform.position.y == 0.5f)
                    {
                        transform.Translate(shortLeft+shortDown);
                        GravityPos = 0;
                    }
                    else
                    {
                        transform.Translate(downWall);
                    }
                    break;
                //Gravedad izquierda -> derecha
                case 3:
                    if (isJumping && transform.position.y ==0.5f)
                    {
                        transform.Translate(shortDown);
                        isJumping = false;
                        GravityPos = 0;
                    }
                    else if (!isJumping && transform.position.y == 0.5f)
                    {
                        transform.Translate(shortRight+shortDown);
                        GravityPos = 0;
                    }
                    else
                    {
                        transform.Translate(downWall);
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
                        transform.Translate(shortLeft+shortUp);
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
                        transform.Translate(shortLeft+shortDown);
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
                        transform.Translate(shortRight+shortUp);
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
                        transform.Translate(shortRight+shortDown);
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
    //Start 
    private void Start()
    {
        VidasUpdate();
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
        if (obstacle.tag == "Obstacle")
        {
            int a = GetVidas();
            SetVidas(a - 1);
            Debug.Log("Choco");
            VidasUpdate();
        }
        else if (obstacle.parent != null && obstacle.parent.tag == "Obstacle")
        {
            int a = GetVidas();
            SetVidas(a - 1);
            VidasUpdate();
        }

    }
}
