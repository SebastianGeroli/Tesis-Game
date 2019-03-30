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
    private int invMax = 9;
    private int invMin = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

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
        timerObs += Time.deltaTime;
        switch (nextObj) {
            case 0:
                if (timerObs > nextObjTime)
                {
                    Instantiate(Resources.Load("HalfWallTop"), transform.position+new Vector3(0,7,0), Quaternion.identity);
                    timerObs = 0;
                    nextObj =(int)Random.Range(invMin, invMax);
                }
                break;
            case 1:
                if (timerObs > nextObjTime)
                {
                    Instantiate(Resources.Load("HalfWallBottom"), transform.position, Quaternion.identity);
                    timerObs = 0;
                    nextObj = (int)Random.Range(invMin, invMax);
                }
                break;
            case 2:
                if (timerObs > nextObjTime)
                {
                    Instantiate(Resources.Load("HalfWallLeft"), transform.position+ new Vector3(-3,4,0), Quaternion.identity);
                    timerObs = 0;
                    nextObj = (int)Random.Range(invMin, invMax);
                }
                break;
            case 3:
                if (timerObs > nextObjTime)
                {
                    Instantiate(Resources.Load("HalfWallRight"), transform.position + new Vector3(3, 4, 0), Quaternion.identity);
                    timerObs = 0;
                    nextObj = (int)Random.Range(invMin, invMax);
                }
                break;
            case 4:
                if (timerObs > nextObjTime)
                {
                    Instantiate(Resources.Load("3_4Top"), transform.position + new Vector3(0, 5, 0), Quaternion.identity);
                    timerObs = 0;
                    nextObj = (int)Random.Range(invMin, invMax);
                }
                break;
            case 5:
                if (timerObs > nextObjTime)
                {
                    Instantiate(Resources.Load("3_4Bottom"), transform.position + new Vector3(0, 3, 0), Quaternion.identity);
                    timerObs = 0;
                    nextObj = (int)Random.Range(invMin, invMax);
                }
                break;
            case 6:
                if (timerObs > nextObjTime)
                {
                    Instantiate(Resources.Load("3_4Left"), transform.position + new Vector3(-1, 4, 0), Quaternion.identity);
                    timerObs = 0;
                    nextObj = (int)Random.Range(invMin, invMax);
                }
                break;
            case 7:
                if (timerObs > nextObjTime)
                {
                    Instantiate(Resources.Load("3_4Right"), transform.position + new Vector3(1, 4, 0), Quaternion.identity);
                    timerObs = 0;
                    nextObj = (int)Random.Range(invMin, invMax);
                }
                break;
            case 8:
                if (timerObs > nextObjTime)
                {
                    
                    GameObject go = Instantiate(Resources.Load("Hexagon"))as GameObject;
                    Quaternion qt = go.transform.rotation;
                    go.transform.position = transform.position+ new Vector3(0,4,0);
                    //Instantiate(Resources.Load("Hexagon"), transform.position + new Vector3(0, 4, 0), qt);
                   
                    timerObs = 0;
                    nextObj = (int)Random.Range(invMin, invMax);
                }
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                break;
        }
        
       

    }
}
