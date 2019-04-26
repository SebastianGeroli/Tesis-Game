using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTexture : MonoBehaviour
{
    /*################################ Variables ##################################*/
    Material material;
    float scrollSpeed = 2f;
    /*################################ Metodos  ##################################*/
    //Start
    private void Start()
    {
        material = transform.GetComponent<Renderer>().material;
    }
    //fixed update
    private void FixedUpdate()
    {
        MoveOffSet();
    }
    //Mover Offset material\
    public void MoveOffSet()
    {
        float offset = Time.time * scrollSpeed;
        material.mainTextureOffset = new Vector2 (0,offset);
        
      
    }
    
}
