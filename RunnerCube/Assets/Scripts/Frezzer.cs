using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frezzer : MonoBehaviour
{
    public Invoker invoker;
    public Obstacles obstacles;
    public GameObject gO;
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

        obstacles = other.GetComponentInParent<Obstacles>();
        Transform tr = other.GetComponent<Transform>();
        //  Debug.Log("Destroyer Entre");
        // Debug.Log(other.name);
        if (tr.parent == null)
        {
            Debug.Log(obstacles.GetposInicial());
            obstacles.LlegoDestino = true;
            tr.transform.position = invoker.obstacles[0].GetposInicial();
        }
        else
        {
            Debug.Log(obstacles.GetposInicial());
                obstacles.LlegoDestino = true;
                tr.transform.parent.position = invoker.obstacles[0].GetposInicial();
        }
    }
}
