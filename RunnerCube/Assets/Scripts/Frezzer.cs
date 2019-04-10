using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frezzer : MonoBehaviour
{
    public Transform invoker;
    public Walls wall;
    public GameObject rb;
    private Rigidbody rb2;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = transform.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        wall = other.GetComponentInParent<Walls>();
        Transform tr = other.GetComponent<Transform>();
        //  Debug.Log("Destroyer Entre");
        // Debug.Log(other.name);
        if (tr.parent == null)
        {
                wall.LlegoDestino = true;
                tr.position = invoker.position;
        }
        else
        {
                wall.LlegoDestino = true;
                tr.position = invoker.position;
           

        }
    }
}
