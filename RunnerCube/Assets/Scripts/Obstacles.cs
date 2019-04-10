using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {
    private int forma;
    public bool LlegoDestino = false;
    public bool PuedeSalir = false;
    public Vector3 posInicial;
    public Rigidbody rb;
    Obstacles obstaculo;
    //Getters && Setters
    public int GetForma() {
        return forma;
    }
    public int SetForma(int a)
    {
        return forma = a;
    }
    //Devolucion Vector3 de posInicial
    public Vector3 GetposInicial() {
        return posInicial;
    }
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

        if (!LlegoDestino && PuedeSalir)
            rb.transform.Translate(0, 0, -0.5f);

    }
}
