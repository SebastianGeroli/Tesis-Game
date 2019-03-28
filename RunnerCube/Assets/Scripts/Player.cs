using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //Jump
    public void Jump() {
        if (transform.position.y < 4) {
            transform.Translate(0, 2, 0);
        }
        
    }
    //Doble Jump 
    public void DobleJump() {
        float posY = transform.position.y;
        int i = (int)posY;
        switch(i)
        {
            case 0:
                transform.Translate(0, 4, 0);
                break;
            case 4:
                transform.Translate(0, -4, 0);
                break;


        }
    }
    //Move Left
    public void MoveLeft() {
        if (transform.position.x > -2) {
            transform.Translate(-2, 0, 0);
        }
        else
        {
            transform.Translate(4, 0, 0);
        }

    }
    //Move Right
    public void MoveRight() {
        if (transform.position.x < 2)
        {
            transform.Translate(2, 0, 0);
        }
        else {
            transform.Translate(-4, 0, 0);
        }
            
    }
    //Stick to left
    //Stick to right
    //Duck
    public void Duck() {
        if (transform.position.y > 0) {
            transform.Translate(0, -2, 0);
        }
        
    }
    //Mueve Al player en Z  NOTA NO ES NECESARIO ROMPE EL CODIGO
    public void MovePlayer()
    {
        transform.Translate(0, 0, 0.25f);
    }
    //Update Con detector de keypressed

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
           Duck();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DobleJump();
        }

    }

}
