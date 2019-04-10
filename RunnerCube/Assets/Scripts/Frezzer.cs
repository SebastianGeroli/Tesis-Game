using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frezzer : MonoBehaviour
{
    //Trigger
    private void OnTriggerEnter(Collider other)
    {
        Transform tr = other.GetComponent<Transform>();
        if (tr.parent == null)
        {
            tr = other.GetComponent<Transform>();
            tr.GetComponent<Obstacles>().LlegoDestino = true;
            tr.transform.position = tr.GetComponent<Obstacles>().GetposInicial();
        }
        else
        {
            tr = other.GetComponentInParent<Transform>();
                tr.GetComponent<Obstacles>().LlegoDestino = true;
                tr.transform.parent.position = tr.GetComponent<Obstacles>().GetposInicial();
        }
    }
}
