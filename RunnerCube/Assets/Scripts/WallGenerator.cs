using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    /*###############################################################################
                                       Variables
    #################################################################################*/
    public GameObject WallGenerators;
    public Vector3 velocity = new Vector3(0, 0, -0.2f);
    /*###############################################################################
                                       Metodos
    #################################################################################*/
    //Fixed Update
    private void FixedUpdate()
    {
        MoveWallGenerator();
    }

    //Move Walls        || mueve las paredes del escenario
    public void MoveWallGenerator()
    {
        transform.Translate(velocity);
    }
}
