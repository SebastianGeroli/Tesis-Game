using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
	public bool LlegoDestino = false;
    // Start is called before the first frame update
    public Rigidbody rb;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void FixedUpdate()
    {
        MoveFloor();
    }
    public void MoveFloor() {
		if(!LlegoDestino)
        rb.transform.Translate(0,0,-0.5f);
		
    }
}
