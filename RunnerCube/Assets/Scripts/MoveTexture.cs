using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTexture : MonoBehaviour
{
    /*################################ Variables ##################################*/
    public GameManagerRunner gameManager;
    Material material;
    float scrollSpeed = 2f;
    public GameObject circuitPath;

    /*################################ Metodos  ##################################*/
    //Start
    private void Start()
    {
        circuitPath = GetComponent<GameObject>();
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
        if (gameObject.tag == "Layer1"){ 
        float offset = Time.time * scrollSpeed * gameManager.speeTexture;
        material.mainTextureOffset = new Vector2 (0,offset * 0.75f);
        }

        if (gameObject.tag == "Layer2")
        {
            float offset = Time.time * scrollSpeed * gameManager.speeTexture;
            material.mainTextureOffset = new Vector2(0, offset * .5f);
        }


    }
    
}
