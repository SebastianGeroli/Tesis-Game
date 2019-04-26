using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    /*################################  Variables  ##################################*/
    private Vector3 velocity = new Vector3(0,0,-0.3f);
    private int forma;
    public bool PuedeSalir = false;
    private Vector3 posInicial;
    public Rigidbody rb;
 
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

    //SetVelocity
    public void SetVelocity(Vector3 vec3) {
        velocity = vec3;
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

        if (PuedeSalir && rb.tag == "Obstacle")
        {
            rb.transform.Translate(velocity);
        }
            

    }

    
}
