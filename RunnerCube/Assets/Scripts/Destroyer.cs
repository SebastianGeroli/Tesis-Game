using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject rb;
    private Rigidbody rb2;
    public float Dvelocity;

    //Mueve el Destroyer NOTA: NO ES NECESARIO ROMPE EL CODIGO
    public void MoveDestroyer()
    {
        transform.Translate(0, 0, Dvelocity);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2 = transform.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
    //    MoveDestroyer();
    //}
    //private void OnTriggerEnter(Collider otherObj)
    //{
    //    Destroy(otherObj.gameObject);
    //    //if (otherObj.gameObject.tag == "Floor")
    //    //{
    //    //    Destroy(otherObj, .5f);
    //    //    Debug.Log("destroyertrigger");
    //    //}
    //    //    rb = other.GetComponent<GameObject>();
    //    //Destroy(rb);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Transform tr = other.GetComponent<Transform>();
        Debug.Log("Destroyer Entre");
        // Debug.Log(other.name);
        if (other.tag == "Boundary")
        {
            return;
        }
        
        Destroy(tr.parent.gameObject);
        //Destroy(gameObject);
        Debug.Log("Destroyer Destruyo");

    }

  
}
