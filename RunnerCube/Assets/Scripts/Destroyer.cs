using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
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
        Transform tr = other.GetComponent<Transform>();
      //  Debug.Log("Destroyer Entre");
        // Debug.Log(other.name);
        if (other.tag == "Boundary")
        {
            return;
        }
        if (tr.parent == null)
        {
            Destroy(tr.gameObject);
        }
        else {
            Destroy(tr.parent.gameObject);
        }
       
        //Destroy(gameObject);
      //  Debug.Log("Destroyer Destruyo");

    }

  
}
