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
  //  private int invMax = 9;
   // private int invMin = 0;
	public Obstacles[] obstacles = new Obstacles[5];
    // Update is called once per frame
    private void Start()
    {
        ObstacleGenerator();
    }
    void Update()
    {
        WallGenerator();
      
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
		obstacles [0] = new Obstacles(0, transform);
		obstacles [1] = new Obstacles(1, transform);
		obstacles [2] = new Obstacles(2, transform);
		obstacles [3] = new Obstacles(3, transform);
		obstacles [4] = new Obstacles(4, transform);
    }
}
