using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    /*################################  Variables  ##################################*/
    private float timer;
    public int GravityPos = 0;
    bool isJumping;
    Transform obstacle;
    /*################################  Metodos  ##################################*/
    //Swipe Up
    public void SwipeUp() {
		if (Input.GetKeyDown(KeyCode.W) || SwipeDetector.Instance.IsSwiping(SwipeDirection.Up)) {
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
    }
    //Swipe Down
    public void SwipeDown()
    {
		if (Input.GetKeyDown (KeyCode.S) || SwipeDetector.Instance.IsSwiping(SwipeDirection.Down))
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
       
    }
    //Swipe Left
    public void SwipeLeft() {
		if (Input.GetKeyDown (KeyCode.A) || SwipeDetector.Instance.IsSwiping(SwipeDirection.Left))
        {
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
       
    }
    //Swipe Right
    public void SwipeRight() {
		if (Input.GetKeyDown (KeyCode.D) || SwipeDetector.Instance.IsSwiping(SwipeDirection.Right))
        {
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
    }
    //Update
    void Update()
    {	// Debugs
        //Debug.Log("Timer: " + timer);
        //Debug.Log("Esta saltando: "+ isJumping);
        //Debug.Log("Gravedad: "+GravityPos);
        //Fin Debugs
		SwipeUp ();
		SwipeRight ();
		SwipeLeft ();
		SwipeDown ();

    }
    //Trigger  || detecta si choca contra los obstaculos
    private void OnTriggerEnter(Collider other)
    {
        obstacle = other.gameObject.GetComponent<Transform>();
        if (obstacle.tag == "Objeto") {
            Debug.Log("Choco");
        }
    }
}
