using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{   /*###############################################################################
                                       Variables
    #################################################################################*/
    public GameObject[] obstacles;
    public float minTime, maxTime;
    private int lastInvoked = 0;
    private int counter;
    private float time;
    private float timerObs;
    private int nextObj;
    // private int invMax = 9;
    // private int invMin = 0;
    /*###############################################################################
                                       Metodos
    #################################################################################*/
    public void ObstacleLauncher()
    {
        timerObs += Time.deltaTime;
        if (timerObs > 0.5f)
        {
            obstacles[counter].GetComponent<Obstacles>().PuedeSalir = true;
            obstacles[counter].GetComponent<Obstacles>().LlegoDestino = false;
            timerObs = 0;
        }
        counter++;
        if (counter == obstacles.Length)
        {
            counter = 0;
        }
    }

    //Obstacle Generator
    public GameObject ObstaclesGen(int Obj, Transform invoker)
    {
        GameObject gO;
        switch (Obj)
        {
            case 0:
                gO = Instantiate(Resources.Load("HalfWallTop"), invoker.position + new Vector3(0, 7, 0), Quaternion.identity) as GameObject;
                break;
            case 1:
                gO = Instantiate(Resources.Load("HalfWallBottom"), invoker.position, Quaternion.identity) as GameObject;
                break;
            case 2:
                gO = Instantiate(Resources.Load("HalfWallLeft"), invoker.position + new Vector3(-3, 4, 0), Quaternion.identity) as GameObject;
                break;
            case 3:
                gO = Instantiate(Resources.Load("HalfWallRight"), invoker.position + new Vector3(3, 4, 0), Quaternion.identity) as GameObject;
                break;
            case 4:
                gO = Instantiate(Resources.Load("3_4Top"), invoker.position + new Vector3(0, 5, 0), Quaternion.identity) as GameObject;
                break;
            case 5:
                gO = Instantiate(Resources.Load("3_4Bottom"), invoker.position + new Vector3(0, 3, 0), Quaternion.identity) as GameObject;
                break;
            case 6:
                gO = Instantiate(Resources.Load("3_4Left"), invoker.position + new Vector3(-1, 4, 0), Quaternion.identity) as GameObject;
                break;
            case 7:
                gO = Instantiate(Resources.Load("3_4Right"), invoker.position + new Vector3(1, 4, 0), Quaternion.identity) as GameObject;
                break;
            //case 8:
            //	gO = Instantiate (Resources.Load ("Hexagon"))as Object;
            //	Quaternion qt = gO.transform.rotation;
            //	gO.transform.position = invoker.position + new Vector3 (0, 4, 0);
            //	return gO;
            default:
                gO = Instantiate(Resources.Load("HalfWallTop"), invoker.position + new Vector3(0, 7, 0), Quaternion.identity) as GameObject;
                break;
        }

        gO.GetComponent<Obstacles>().SetposInicial(gO.GetComponent<Transform>().position);
        gO.GetComponent<Obstacles>().SetForma(Obj);
        return gO;
    }

    //Creador de paredes no interactivas 
    public void WallGenerator()
    {
        time += Time.deltaTime;
        if (lastInvoked == 0 && time > 0.31f)
        {
            Instantiate(Resources.Load("WhiteWalls"), transform.position, Quaternion.identity);
            lastInvoked = 1;
            time = 0;
        }
        else if (time > 0.31f)
        {
            Instantiate(Resources.Load("BlueWalls"), transform.position, Quaternion.identity);
            lastInvoked = 0;
            time = 0;
        }

    }

    //Creador de obstaculos
    public void ObstacleGenerator()
    {
        obstacles[0] = ObstaclesGen(0, transform);
        obstacles[1] = ObstaclesGen(1, transform);
        obstacles[2] = ObstaclesGen(2, transform);
        obstacles[3] = ObstaclesGen(3, transform);
        obstacles[4] = ObstaclesGen(4, transform);
    }
}
