using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject WallGenerators;
    public Vector3 velocity = new Vector3(0, 0, -0.2f);
    public float minTime;
    public float maxTime;
    public float spawnTime = 1f;
    private void FixedUpdate()
    {
        MoveWallGenerator();
    }
    public void MoveWallGenerator()
    {
        transform.Translate(velocity);
    }
}
