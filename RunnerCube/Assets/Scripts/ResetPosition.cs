﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    
    /*################################  Metodos  ##################################*/
    //OnTrigger ResetPos
    private void OnTriggerEnter(Collider other)
    {
        Transform tr = other.GetComponent<Transform>();
        if (tr.parent == null && tr.tag == "Escenario")
        {
            tr.GetComponent<Obstacles>().PuedeSalir = false;
            tr.transform.position = tr.GetComponent<Obstacles>().GetposInicial();
        }
        else if (tr.parent != null && tr.parent.tag =="Escenario")
        {
            tr.parent.GetComponent<Obstacles>().PuedeSalir = false;
            tr.parent.transform.position = tr.parent.GetComponent<Obstacles>().GetposInicial();
        }else if (tr.parent == null && tr.tag == "Obstacle")
        {
            tr = other.GetComponent<Transform>();
            tr.GetComponent<Obstacles>().PuedeSalir = false;
            tr.transform.position = tr.GetComponent<Obstacles>().GetposInicial();
        }
        else if (tr.parent != null && tr.parent.tag == "Obstacle")
        {
            tr.GetComponentInParent<Obstacles>().PuedeSalir = false;
            tr.transform.parent.position = tr.GetComponentInParent<Obstacles>().GetposInicial();
        }
    }
}