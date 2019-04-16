using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    //OnTrigger ResetPos
    private void OnTriggerEnter(Collider other)
    {
        Transform tr = other.GetComponent<Transform>();
        if (tr.parent == null && tr.tag == "Escenario")
        {
            tr = other.GetComponent<Transform>();
            tr.GetComponent<Obstacles>().LlegoDestino = true;
            tr.transform.position = tr.GetComponent<Obstacles>().GetposInicial();
        }
        else if (tr.parent != null && tr.parent.tag =="Escenario")
        {
            tr = other.GetComponent<Transform>();
            tr.parent.GetComponent<Obstacles>().LlegoDestino = true;
         
            tr.parent.transform.position = tr.parent.GetComponent<Obstacles>().GetposInicial();
        }
    }

    //OnTrigger Destroy
    //private void OnTriggerEnter(Collider other)
    //{
    //    Transform tr = other.GetComponent<Transform>();
    //    //  Debug.Log("Destroyer Entre");
    //    // Debug.Log(other.name);
    //    if (tr.parent != null) {
    //        if (tr.parent.tag == "Escenario")
    //        {
    //            Destroy(tr.parent.gameObject);
    //        }
    //    }else if (tr.tag == "Escenario") {
    //        Destroy(tr.gameObject);
    //    }
    //}

  
}
