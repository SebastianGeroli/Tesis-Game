using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
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
		wall = other.GetComponent<Walls> ();
        Transform tr = other.GetComponent<Transform>();
      //  Debug.Log("Destroyer Entre");
        // Debug.Log(other.name);
        if (other.tag == "Boundary")
        {
            return;
        }
        if (tr.parent == null)
        {
			if (tr.parent.tag == "Escenario") {
				Destroy(tr.gameObject);
			}
            //Destroy(tr.gameObject);
			wall.LlegoDestino = true;
			tr.position = invoker.position;
        }
        else {
			if (tr.parent.tag == "Escenario") {
				Destroy(tr.parent.gameObject);
			}
            //Destroy(tr.parent.gameObject);
			wall.LlegoDestino = true;
			tr.position = invoker.position;
        }
       
        //Destroy(gameObject);
      //  Debug.Log("Destroyer Destruyo");

    }

  
}
