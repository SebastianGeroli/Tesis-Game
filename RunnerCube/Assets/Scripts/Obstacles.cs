﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    /*################################  Variables  ##################################*/
    private int forma;
    public bool LlegoDestino = false;
    public bool PuedeSalir = false;
    private Vector3 posInicial;
    public Rigidbody rb;
    Obstacles obstaculo;
    /*################################  Getters && Setters  ##################################*/
    //Get & Set de Forma
    public int GetForma()
    {
        return forma;
    }
    public int SetForma(int a)
    {
        return forma = a;
    }

    //Get & Set de GetPosInicial
    public Vector3 GetposInicial()
    {
        return posInicial;
    }
    public void SetposInicial(Vector3 a)
    {
        posInicial = a;
    }
    /*################################  Metodos  ##################################*/
    //Start
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    //Fixed Update
    private void FixedUpdate()
    {
        MoveFloor();
    }

    //Mover Los Obstaculos
    public void MoveFloor()
    {

        if (!LlegoDestino && PuedeSalir && rb.tag == "Obstacle")
        {
            rb.transform.Translate(0, 0, -0.3f);
        }
        else if(!LlegoDestino && PuedeSalir && rb.tag == "Escenario") {
            rb.transform.Translate(0, 0, -0.34f);
        }
            

    }
}
