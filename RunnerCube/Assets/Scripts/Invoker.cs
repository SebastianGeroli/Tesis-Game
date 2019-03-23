using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    public GameObject invocador;
    public float minTime,maxTime;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        generator();
    }
    public void generator() {
        invocador.tag = "Floor";
        Instantiate(invocador,transform.position, Quaternion.identity);
    }
}
