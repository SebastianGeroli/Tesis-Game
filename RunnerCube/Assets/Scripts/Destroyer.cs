using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Transform tr = other.GetComponent<Transform>();
        //  Debug.Log("Destroyer Entre");
        // Debug.Log(other.name);
        if (tr.parent != null) {
            if (tr.parent.tag == "Escenario")
            {
                Destroy(tr.parent.gameObject);
            }
        }else if (tr.tag == "Escenario") {
            Destroy(tr.gameObject);
        }
    }

  
}
