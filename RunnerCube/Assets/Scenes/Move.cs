using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Forward();   
    }

    public void Forward() {
        if (Input.GetKeyDown(KeyCode.W)) {
            anim.SetBool("MOVE", true);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            anim.SetBool("MOVE", false);

        }
    }
}
