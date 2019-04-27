using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{  /*################################  Variables  ##################################*/
    public float minTime;
    public GameObject[] obstacles = new GameObject[18];
    [SerializeField]
    private int counterObstacle = 0;
    private float timerObs = 0;
    // private int invMax = 9;
    // private int invMin = 0;
    /*################################  Metodos  ##################################*/
    //Obstacle Generator
    public GameObject ObstaclesGen(int Obj, Transform invoker)
    {
        GameObject gO;
        switch (Obj)
        {
            case 0:
                gO = Instantiate(Resources.Load("Middle"), invoker.position, Quaternion.identity) as GameObject;
                break;
            case 1:
                gO = Instantiate(Resources.Load("Middle"), invoker.position, Quaternion.Euler(0, 0, 90)) as GameObject;
                break;
            case 2:
                gO = Instantiate(Resources.Load("MiddleFull"), invoker.position, Quaternion.identity) as GameObject;
                break;
            case 3:
                gO = Instantiate(Resources.Load("MiddleFull"), invoker.position, Quaternion.Euler(0, 0, 90)) as GameObject;
                break;
            case 4:
                gO = Instantiate(Resources.Load("MiddleUP"), invoker.position, Quaternion.identity) as GameObject;
                break;
            case 5:
                gO = Instantiate(Resources.Load("MiddleUP"), invoker.position, Quaternion.Euler(0, 0, 90)) as GameObject;
                break;
            case 6:
                gO = Instantiate(Resources.Load("MiddleUP"), invoker.position, Quaternion.Euler(0, 0, -90)) as GameObject;
                break;
            case 7:
                gO = Instantiate(Resources.Load("MiddleUP"), invoker.position, Quaternion.Euler(0, 0, 180)) as GameObject;
                break;
            case 8:
                gO = Instantiate(Resources.Load("Short"), invoker.position , Quaternion.identity) as GameObject;
                break;
            case 9:
                gO = Instantiate(Resources.Load("Short"), invoker.position, Quaternion.Euler(0, 0, 90)) as GameObject;
                break;
            case 10:
                gO = Instantiate(Resources.Load("Short"), invoker.position, Quaternion.Euler(0, 0, -90)) as GameObject;
                break;
            case 11:
                gO = Instantiate(Resources.Load("Short"), invoker.position, Quaternion.Euler(0, 0, 180)) as GameObject;
                break;
            case 12:
                gO = Instantiate(Resources.Load("Corner"), invoker.position, Quaternion.identity) as GameObject;
                break;
            case 13:
                gO = Instantiate(Resources.Load("Corner"), invoker.position, Quaternion.Euler(0, 0, 90)) as GameObject;
                break;
            case 14:
                gO = Instantiate(Resources.Load("Corner"), invoker.position, Quaternion.Euler(0, 0, -90)) as GameObject;
                break;
            case 15:
                gO = Instantiate(Resources.Load("Corner"), invoker.position, Quaternion.Euler(0, 0, 180)) as GameObject;
                break;
            case 16:
                gO = Instantiate(Resources.Load("Corners"), invoker.position, Quaternion.identity) as GameObject;
                break;
            case 17:
                gO = Instantiate(Resources.Load("CornersMiddle"), invoker.position, Quaternion.identity) as GameObject;
                break;
            default:
                gO = Instantiate(Resources.Load("Corner"), invoker.position, Quaternion.identity) as GameObject;
                break;
        }

        gO.GetComponent<Obstacles>().SetposInicial(gO.GetComponent<Transform>().position);
        gO.GetComponent<Obstacles>().SetForma(Obj);
        return gO;
    }

    //Instancite de obstaculos
    public void ObstacleInstanciate()
    {
        obstacles[0] = ObstaclesGen(0, transform);
        obstacles[1] = ObstaclesGen(1, transform);
        obstacles[2] = ObstaclesGen(2, transform);
        obstacles[3] = ObstaclesGen(3, transform);
        obstacles[4] = ObstaclesGen(4, transform);
        obstacles[5] = ObstaclesGen(5, transform);
        obstacles[6] = ObstaclesGen(6, transform);
        obstacles[7] = ObstaclesGen(7, transform);
        obstacles[8] = ObstaclesGen(8, transform);
        obstacles[9] = ObstaclesGen(9, transform);
        obstacles[10] = ObstaclesGen(10, transform);
        obstacles[11] = ObstaclesGen(11, transform);
        obstacles[12] = ObstaclesGen(12, transform);
        obstacles[13] = ObstaclesGen(13, transform);
        obstacles[14] = ObstaclesGen(14, transform);
        obstacles[15] = ObstaclesGen(15, transform);
        obstacles[16] = ObstaclesGen(16, transform);
        obstacles[17] = ObstaclesGen(17, transform);

    }

    //Obstacle Launcher
    public float ObstacleLauncher()
    {
        timerObs += Time.deltaTime;
        if (timerObs > 2f && obstacles[counterObstacle].GetComponent<Obstacles>().PuedeSalir == false)
        {
            obstacles[counterObstacle].GetComponent<Obstacles>().PuedeSalir = true;
            timerObs = 0;
            counterObstacle =(int) Random.Range(0,17);
        }else
        {
            counterObstacle =(int)Random.Range(0, 17);
        }
       
        
        return timerObs;
    }
}




