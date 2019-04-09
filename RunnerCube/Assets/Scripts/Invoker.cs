using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    public float minTime,maxTime;
    private int lastInvoked = 0;
    private float time;
    private float timerObs;
    private int nextObj;
    private float nextObjTime = 1f;
	private Obstacles obs = new Obstacles();
  //  private int invMax = 9;
   // private int invMin = 0;
	private GameObject[] obstacles = new GameObject[5];
    // Update is called once per frame
    void Update()
    {
        WallGenerator();
        ObstacleGenerator();
    }
    //Creador de paredes no interactivas 
    public void WallGenerator() {
        time += Time.deltaTime;
        if (lastInvoked == 0&& time>0.31f){
            Instantiate(Resources.Load("WhiteWalls"), transform.position, Quaternion.identity);
            lastInvoked = 1;
            time = 0;
        }
        else if(time>0.31f){
            Instantiate(Resources.Load("BlueWalls"), transform.position, Quaternion.identity);
            lastInvoked = 0;
            time = 0;
        }
        
    }
    //Creador de obstaculos
    public void ObstacleGenerator() {
		obstacles [0] = obs.ObstaclesConstructor (0, transform);
		obstacles [1] = obs.ObstaclesConstructor (1, transform);
		obstacles [2] = obs.ObstaclesConstructor (2, transform);
		obstacles [3] = obs.ObstaclesConstructor (3, transform);
		obstacles [4] = obs.ObstaclesConstructor (4, transform);
    }
}
