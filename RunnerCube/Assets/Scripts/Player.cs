using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player:MonoBehaviour
{
    public GameManagerRunner gameManager;
    /*################################  Variables  ##################################*/
    public bool aKeyWasPressed;
    public float velocidadDeMovimiento = 0.3f;
    public Text vidasText;
    private int vidas = 5;
    private float timer;
    public int GravityPos = 0;
    bool isJumping;
    Transform obstacle;
    SwipeData data;
    /*################################  Variables de movimiento || Vectors 3 ##################################*/
    private Vector3 up1 = new Vector3(0 , 2.5f , 0);
    private Vector3 up2 = new Vector3(0 , 2.5f , 0);
    private Vector3 down1 = new Vector3(0 , -2.5f , 0);
    private Vector3 down2 = new Vector3(0 , -2.5f , 0);
    private Vector3 upWall = new Vector3(0 , 2 , 0);
    private Vector3 downWall = new Vector3(0 , -2 , 0);
    private Vector3 right = new Vector3(2 , 0 , 0);
    private Vector3 left = new Vector3(-2 , 0 , 0);
    private Vector3 shortRight = new Vector3(0.5f , 0 , 0);
    private Vector3 shortLeft = new Vector3(-0.5f , 0 , 0);
    private Vector3 shortUp = new Vector3(0 , 0.5f , 0);
    private Vector3 shortDown = new Vector3(0 , -0.5f , 0);
    private Vector3 LongRight = new Vector3(2.5f , 0 , 0);
    private Vector3 LongLeft = new Vector3(-2.5f , 0 , 0);
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
    public void VidasUpdate()
    {
        vidasText.text = GetVidas().ToString();
    }

    //Swipe Up
    public void SwipeUp()
    {
        if ( Input.GetKeyDown(KeyCode.W) || data.Direction == SwipeDirection.Up )
        {
            data.Direction = SwipeDirection.None;
            switch ( GravityPos )
            {
                //Gravedad  arriba -> abajo
                case 0:
                    if ( !isJumping && transform.position.y != 2 )
                    {
                        AnimatePosition(up1);
                        isJumping = true;
                    }
                    else if ( isJumping && transform.position.y != 4 )
                    {
                        AnimatePosition(up2);
                        isJumping = false;
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , 180));
                        GravityPos = 1;
                    }
                    break;
                //Gravedad abajo -> arriba
                case 1:
                    if ( isJumping )
                    {
                        AnimatePosition(up2);
                        isJumping = false;
                    }
                    break;
                //Gravedad derecha -> izquierda
                case 2:
                    if ( isJumping && transform.position.y == 4.5f )
                    {
                        AnimatePosition(shortUp);
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , 180));
                        isJumping = false;
                        GravityPos = 1;
                    }
                    else if ( transform.position.y != 4.5f )
                    {
                        AnimatePosition(upWall);
                    }
                    else if ( !isJumping && transform.position.y == 4.5f )
                    {
                        AnimatePosition(shortLeft + shortUp);
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , 180));
                        GravityPos = 1;
                    }

                    break;
                //Gravedad izquierda -> derecha
                case 3:
                    if ( isJumping && transform.position.y == 4.5f )
                    {
                        AnimatePosition(shortUp);
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , 180));
                        isJumping = false;
                        GravityPos = 1;
                    }
                    else if ( transform.position.y != 4.5f )
                    {
                        AnimatePosition(upWall);
                    }
                    else if ( !isJumping && transform.position.y == 4.5f )
                    {
                        AnimatePosition(shortRight + shortUp);
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , 180));
                        GravityPos = 1;
                    }

                    break;
            }
        }
    }

    //Swipe Down
    public void SwipeDown()
    {
        if ( Input.GetKeyDown(KeyCode.S) || data.Direction == SwipeDirection.Down )
        {
            data.Direction = SwipeDirection.None;
            switch ( GravityPos )
            {
                //Gravedad abajo -> arriba
                case 0:
                    if ( isJumping )
                    {
                        AnimatePosition(down1);
                        isJumping = false;
                    }
                    break;
                //Gravedad arriba -> abajo
                case 1:
                    if ( !isJumping && transform.position.y != 0 )
                    {

                        AnimatePosition(down2);
                        isJumping = true;
                    }
                    else if ( isJumping && transform.position.y != 0 )
                    {
                        AnimatePosition(down1);
                        isJumping = false;
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , 0));
                        GravityPos = 0;
                    }
                    break;
                //Gravedad derecha -> izquierda
                case 2:
                    if ( isJumping && transform.position.y == 0.5f )
                    {
                        AnimatePosition(shortDown);
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , 0));
                        isJumping = false;
                        GravityPos = 0;
                    }
                    else if ( !isJumping && transform.position.y == 0.5f )
                    {
                        AnimatePosition(shortLeft + shortDown);
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , 0));
                        GravityPos = 0;
                    }
                    else
                    {
                        AnimatePosition(downWall);
                    }
                    break;
                //Gravedad izquierda -> derecha
                case 3:
                    if ( isJumping && transform.position.y == 0.5f )
                    {
                        AnimatePosition(shortDown);
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , 0));
                        isJumping = false;
                        GravityPos = 0;
                    }
                    else if ( !isJumping && transform.position.y == 0.5f )
                    {
                        AnimatePosition(shortRight + shortDown);
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , 0));
                        GravityPos = 0;
                    }
                    else
                    {
                        AnimatePosition(downWall);
                    }
                    break;
            }
        }

    }

    //Swipe Left
    public void SwipeLeft()
    {
        if ( Input.GetKeyDown(KeyCode.A) || data.Direction == SwipeDirection.Left )
        {
            data.Direction = SwipeDirection.None;
            switch ( GravityPos )
            {
                //Gravedad abajo -> arriba
                case 0:
                    if ( isJumping && transform.position.x == -2 )
                    {
                        AnimatePosition(shortLeft);
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , 90));
                        isJumping = false;
                        GravityPos = 3;
                    }
                    else if ( !isJumping && transform.position.x == -2 )
                    {
                        AnimatePosition(shortLeft + shortUp);
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , 90));
                        GravityPos = 3;

                    }
                    else if ( transform.position.x != -2 )
                    {
                        AnimatePosition(left);
                    }
                    break;
                //Gravedad arriba -> abajo
                case 1:
                    if ( isJumping && transform.position.x == -2 )
                    {
                        AnimatePosition(shortLeft);
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , 90));
                        isJumping = false;
                        GravityPos = 3;
                    }
                    else if ( !isJumping && transform.position.x == -2 )
                    {
                        AnimatePosition(shortLeft + shortDown);
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , 90));
                        GravityPos = 3;

                    }
                    else if ( transform.position.x != -2 )
                    {
                        AnimatePosition(left);
                    }
                    break;
                //Gravedad derecha -> izquierda
                case 2:
                    if ( !isJumping && transform.position.x == 2.5f )
                    {
                        AnimatePosition(LongLeft);
                        isJumping = true;
                    }
                    else if ( isJumping && transform.position.x != -2.5f )
                    {
                        AnimatePosition(LongLeft);
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , 90));
                        isJumping = false;
                        GravityPos = 3;
                    }

                    break;
                //Gravedad izquierda -> derecha
                case 3:
                    if ( isJumping )
                    {
                        AnimatePosition(LongLeft);
                        isJumping = false;
                    }
                    break;
            }
        }

    }

    //Swipe Right
    public void SwipeRight()
    {
        if ( Input.GetKeyDown(KeyCode.D) || data.Direction == SwipeDirection.Right )
        {
            data.Direction = SwipeDirection.None;
            switch ( GravityPos )
            {
                //Gravedad abajo -> arriba
                case 0:
                    if ( isJumping && transform.position.x == 2 )
                    {
                        AnimatePosition(shortRight);
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , -90));
                        isJumping = false;
                        GravityPos = 2;

                    }

                    else if ( !isJumping && transform.position.x == 2 )
                    {
                        AnimatePosition(shortRight + shortUp);
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , -90));
                        GravityPos = 2;

                    }
                    else if ( transform.position.x != 2 )
                    {
                        AnimatePosition(right);
                    }
                    break;
                //Gravedad arriba -> abajo
                case 1:
                    if ( isJumping && transform.position.x == 2 )
                    {
                        AnimatePosition(shortRight);
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , -90));
                        isJumping = false;
                        GravityPos = 2;

                    }

                    else if ( !isJumping && transform.position.x == 2 )
                    {
                        AnimatePosition(shortRight + shortDown);
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , -90));
                        GravityPos = 2;

                    }
                    else if ( transform.position.x != 2 )
                    {
                        AnimatePosition(right);
                    }
                    break;
                //Gravedad derecha -> izquierda
                case 2:
                    if ( isJumping )
                    {
                        AnimatePosition(LongRight);
                        isJumping = false;
                    }
                    break;
                //Gravedad izquierda -> derecha
                case 3:
                    if ( !isJumping && transform.position.x == -2.5f )
                    {

                        AnimatePosition(LongRight);
                        isJumping = true;
                    }
                    else if ( isJumping && transform.position.x != 2.5f )
                    {
                        AnimatePosition(LongRight);
                        isJumping = false;
                        transform.rotation = Quaternion.Euler(new Vector3(0 , 180 , -90));
                        GravityPos = 2;
                    }
                    break;
            }
        }
    }

    void AnimatePosition(Vector3 translateVector)
    {

        transform.DOMove(transform.position + translateVector , velocidadDeMovimiento);
    }

    //SwipeLogger
    private void SwipeDetector_OnSwipe(SwipeData dat)
    {
        data = dat;
    }
    //Awake
    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
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
        if ( !gameManager.pause )
        {
            if ( !DOTween.IsTweening(transform) )
            {
                SwipeUp();
                SwipeRight();
                SwipeLeft();
                SwipeDown();
            }

        }


    }

    //Trigger  || detecta si choca contra los obstaculos
    private void OnTriggerEnter(Collider other)
    {
        obstacle = other.gameObject.GetComponent<Transform>();
        if ( obstacle.tag == "Obstacle" || obstacle.tag == "Corner" )
        {
            SetVidas(GetVidas() - 1);
            VidasUpdate();
        }
        else if ( obstacle.parent != null && obstacle.parent.tag == "Obstacle" || obstacle.parent != null && obstacle.parent.tag == "Corner" )
        {

            SetVidas(GetVidas() - 1);
            VidasUpdate();
        }

    }
}
