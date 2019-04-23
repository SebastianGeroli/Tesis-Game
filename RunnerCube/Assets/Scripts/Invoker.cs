using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{  /*################################  Variables  ##################################*/
    public float minTime;
    private float timeWallsInv = 0.27f;
    private GameObject[] obstacles = new GameObject[11];
    private GameObject[] walls = new GameObject[24];
    private Vector3 correccionUP = new Vector3(0, 0.5f, 0);
    private Vector3 correccionLeft = new Vector3(-0.5f, 0, 0);
    private Vector3 correccionRight = new Vector3(0.5f, 0, 0);
    private Vector3 correccionDown = new Vector3(0, -0.5f, 0);
    private int counterObstacle, counterWalls,nextObj;
    private float timerWalls, timerObs;
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
                gO = Instantiate(Resources.Load("MiddleFull"), invoker.position, Quaternion.identity) as GameObject;
                break;
            case 2:
                gO = Instantiate(Resources.Load("MiddleUP"), invoker.position, Quaternion.identity) as GameObject;
                break;
            case 3:
                gO = Instantiate(Resources.Load("Short"), invoker.position , Quaternion.identity) as GameObject;
                break;
            case 4:
                gO = Instantiate(Resources.Load("MiddleFull"), invoker.position, Quaternion.Euler(0,0,90)) as GameObject;
                break;
            case 5:
                gO = Instantiate(Resources.Load("MiddleUP"), invoker.position, Quaternion.identity) as GameObject;
                break;
            case 6:
                gO = Instantiate(Resources.Load("Corner"), invoker.position, Quaternion.Euler(0, 0, 90)) as GameObject;
                break;
            case 7:
                gO = Instantiate(Resources.Load("Corner"), invoker.position, Quaternion.Euler(0, 0, -90)) as GameObject;
                break;
            default:
                gO = Instantiate(Resources.Load("Corner"), invoker.position + correccionUP, Quaternion.identity) as GameObject;
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
        obstacles[8] = ObstaclesGen(0, transform);
        obstacles[9] = ObstaclesGen(1, transform);
        obstacles[10] = ObstaclesGen(2, transform);
        //obstacles[11] = ObstaclesGen(3, transform);
        //obstacles[12] = ObstaclesGen(4, transform);
        //obstacles[13] = ObstaclesGen(5, transform);
        //obstacles[14] = ObstaclesGen(6, transform);
        //obstacles[15] = ObstaclesGen(7, transform);

    }

    //Obstacle Launcher
    public void ObstacleLauncher()
    {
        timerObs += Time.deltaTime;
        if (timerObs > 1.5f)
        {
            obstacles[counterObstacle].GetComponent<Obstacles>().PuedeSalir = true;
            obstacles[counterObstacle].GetComponent<Obstacles>().LlegoDestino = false;
            timerObs = 0;
        }
        counterObstacle++;
        if (counterObstacle == obstacles.Length)
        {
            counterObstacle = 0;
        }
    }

    //Walls Generator|| Escenario
    public GameObject WallsGen(int Form, Transform invoker)
    {
        GameObject gO;
        switch (Form)
        {
            case 0:
                gO = Instantiate(Resources.Load("Walls6x6"), invoker.position, Quaternion.identity) as GameObject;
                break;
            case 1:
                gO = Instantiate(Resources.Load("Walls6x6"), invoker.position, Quaternion.identity) as GameObject;
                break;
            default:
                gO = Instantiate(Resources.Load("Walls6x6"), invoker.position, Quaternion.identity) as GameObject;
                break;
        }
        gO.GetComponent<Obstacles>().SetposInicial(gO.GetComponent<Transform>().position);
        gO.GetComponent<Obstacles>().SetForma(Form);
        return gO;
    }

    //Instanciate de Walls || Instanciador de escenario
    public void WallsInstanciate() {
        //Solo una
        walls[0] = WallsGen(0, transform);
        walls[1] = WallsGen(0, transform);
        walls[2] = WallsGen(0, transform);
        walls[3] = WallsGen(0, transform);
        walls[4] = WallsGen(0, transform);
        walls[5] = WallsGen(0, transform);
        walls[6] = WallsGen(0, transform);
        walls[7] = WallsGen(0, transform);
        walls[8] = WallsGen(0, transform);
        walls[9] = WallsGen(0, transform);
        walls[10] = WallsGen(0, transform);
        walls[11] = WallsGen(0, transform);
        walls[12] = WallsGen(0, transform);
        walls[13] = WallsGen(0, transform);
        walls[14] = WallsGen(0, transform);
        walls[15] = WallsGen(0, transform);
        walls[16] = WallsGen(0, transform);
        walls[17] = WallsGen(0, transform);
        walls[18] = WallsGen(0, transform);
        walls[19] = WallsGen(0, transform);
        walls[20] = WallsGen(0, transform);
        walls[21] = WallsGen(0, transform);
        walls[22] = WallsGen(0, transform);
        walls[23] = WallsGen(0, transform);
        // una y una 
        //walls[0] = WallsGen(0, transform);
        //walls[1] = WallsGen(1, transform);
        //walls[2] = WallsGen(0, transform);
        //walls[3] = WallsGen(1, transform);
        //walls[4] = WallsGen(0, transform);
        //walls[5] = WallsGen(1, transform);
        //walls[6] = WallsGen(0, transform);
        //walls[7] = WallsGen(1, transform);
        //walls[8] = WallsGen(0, transform);
        //walls[9] = WallsGen(1, transform);
        //walls[10] = WallsGen(0, transform);
        //walls[11] = WallsGen(1, transform);
        //walls[12] = WallsGen(0, transform);
        //walls[13] = WallsGen(1, transform);
        //walls[14] = WallsGen(0, transform);
        //walls[15] = WallsGen(1, transform);
        //walls[16] = WallsGen(0, transform);
        //walls[17] = WallsGen(1, transform);
        //walls[18] = WallsGen(0, transform);
        //walls[19] = WallsGen(1, transform);
        //walls[20] = WallsGen(0, transform);
        //walls[21] = WallsGen(1, transform);
        //walls[22] = WallsGen(0, transform);
        //walls[23] = WallsGen(1, transform);
    }

    //Creador de paredes no interactivas 
    public void WallsLauncher()
    {
        timerWalls += Time.deltaTime;
        if (timerWalls > timeWallsInv)
        {
            walls[counterWalls].GetComponent<Obstacles>().PuedeSalir = true;
            walls[counterWalls].GetComponent<Obstacles>().LlegoDestino = false;
            timerWalls = 0;
        }
        counterWalls++;
        if (counterWalls == walls.Length)
        {
            counterWalls = 0;
        }

    }

}



