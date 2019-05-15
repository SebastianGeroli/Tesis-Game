using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTexture : MonoBehaviour
{
    /*################################ Variables ##################################*/
    public GameManagerRunner gameManager;
    Material material;
    float scrollSpeed = 2f;
    /*################################ Metodos  ##################################*/
    //Start
    private void Start()
    {
        gameManager = FindObjectOfType<GameManagerRunner>();
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
        float offset = Time.time * scrollSpeed * gameManager.speeTexture;
        material.mainTextureOffset = new Vector2 (0,offset);
        
      
    }
    
}
