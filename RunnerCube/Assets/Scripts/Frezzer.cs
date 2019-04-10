using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frezzer : MonoBehaviour
{
    public Invoker invoker;
    public Transform gO;
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

        
        Transform tr = other.GetComponent<Transform>();
        //  Debug.Log("Destroyer Entre");
        // Debug.Log(other.name);
        if (tr.parent == null)
        {
            gO = other.GetComponent<Transform>();
            gO.GetComponent<Obstacles>().LlegoDestino = true;
            tr.transform.position = gO.GetComponent<Obstacles>().GetposInicial();
        }
        else
        {
            gO = other.GetComponentInParent<Transform>();
                gO.GetComponent<Obstacles>().LlegoDestino = true;
                tr.transform.parent.position = gO.GetComponent<Obstacles>().GetposInicial();
        }
    }
}
