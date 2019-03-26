using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject rb;
    private Rigidbody rb2;
    public float Dvelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = transform.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveDestroyer();
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
        Debug.Log("entre");
        // Debug.Log(other.name);
        if (other.tag == "Boundary")
        {
            return;
        }
        Destroy(other.gameObject);
        //Destroy(gameObject);
        Debug.Log("destrui");

    }

    public void MoveDestroyer()
    {
        transform.Translate(0, 0, Dvelocity);
    }
}
