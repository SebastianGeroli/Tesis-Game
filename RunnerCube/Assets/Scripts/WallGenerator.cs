using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject WallGenerators;
    //public GameObject wallRight;
    //public GameObject wallLeft;
    //public GameObject floor;
    //public GameObject roof;

    public float minTime;
    public float maxTime;
    public float spawnTime = 1f;
    //  private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(GenerateBack());
        // rb = new Rigidbody2D();
        //Generator();
        //wall = new GameObject[3];

    }

    //void Generator()
    //{
    //    //int currentLevel = Camera.main.GetComponent<LevelController>().currentLevel;
    //    //if (currentLevel > 1)
    //    //    return;
    //    Instantiate(WallGenerators, transform.position, Quaternion.identity);

    //    Invoke("Generator", Random.Range(minTime, maxTime));

    //}
    IEnumerator GenerateBack()
    {
        
       
        Instantiate(WallGenerators, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(GenerateBack());
        Debug.Log("CoRoutine");
    }

    // Update is called once per frame
    void Update()
    {

        MoveWallGenerator();


    }

    public void MoveWallGenerator()
    {
        transform.Translate(0, 0, 0.5f);
    }
}
