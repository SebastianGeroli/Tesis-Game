using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{  /*################################  Variables  ##################################*/
    public bool useRandom = true;
    public List<GameObject> obstacles;
    [SerializeField]
    private float launchTime = 2.0f;
    [SerializeField]
    private int counterObstacle = 0;
    private float timerObs = 0;
    private int maxObj = 17;
    private int lastObj;
    /*################################  Getters && Setters  ##################################*/
    public void SetlaunchTime(float a) {
        launchTime = a;
    }
    public float GetlaunchTime()
    {
        return launchTime;
    }
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
        for ( int a = 0 ; a <= maxObj ; a++ )
        {
            obstacles.Add(ObstaclesGen(a , transform));
        }
    }

    //Obstacle Launcher
    public float ObstacleLauncher()
    {
        timerObs += Time.deltaTime;
       
        if ( useRandom )
        {
            if ( timerObs > launchTime && obstacles[counterObstacle].GetComponent<Obstacles>().PuedeSalir == false )
            {
                obstacles[counterObstacle].GetComponent<Obstacles>().PuedeSalir = true;
                timerObs = 0;
                lastObj = counterObstacle;
                counterObstacle = (int) Random.Range(0 , obstacles.Count);
            }
            else if ( obstacles[counterObstacle].GetComponent<Obstacles>().PuedeSalir == true || obstacles[counterObstacle].tag == obstacles[lastObj].tag && obstacles[lastObj].tag == "Corner" )
            {
                counterObstacle = (int) Random.Range(0 , obstacles.Count);
            }
        }
        else
        {
            if ( timerObs > launchTime && obstacles[counterObstacle].GetComponent<Obstacles>().PuedeSalir == false )
            {
                obstacles[counterObstacle].GetComponent<Obstacles>().PuedeSalir = true;
                timerObs = 0;
                counterObstacle++;
            }
            if ( counterObstacle >= obstacles.Count )
            {
                counterObstacle = 0;
            }
        }
        
        return timerObs;
    }
}




