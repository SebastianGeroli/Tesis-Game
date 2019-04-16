using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{   /*###############################################################################
                                       Variables
    #################################################################################*/
    public float minTime;
    private float timeWallsInv = 0.27f;
    private int lastInvoked = 0;
    private GameObject[] obstacles = new GameObject[11];
    private GameObject[] walls = new GameObject[12];
   
    private int counterObstacle, counterWalls,nextObj;
    private float timerWalls, timerObs;

    // private int invMax = 9;
    // private int invMin = 0;
    /*###############################################################################
                                       Metodos
    #################################################################################*/
    
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
        if (timerObs > 1f)
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
                gO = Instantiate(Resources.Load("BlueWalls"), invoker.position, Quaternion.identity) as GameObject;
                break;
            case 1:
                gO = Instantiate(Resources.Load("WhiteWalls"), invoker.position, Quaternion.identity) as GameObject;
                break;
            default:
                gO = Instantiate(Resources.Load("BlueWalls"), invoker.position, Quaternion.identity) as GameObject;
                break;
        }
        gO.GetComponent<Obstacles>().SetposInicial(gO.GetComponent<Transform>().position);
        gO.GetComponent<Obstacles>().SetForma(Form);
        return gO;
    }

    //Instanciate de Walls || Instanciador de escenario
    public void WallsInstanciate() {
        walls[0] = WallsGen(0, transform);
        walls[1] = WallsGen(1, transform);
        walls[2] = WallsGen(0, transform);
        walls[3] = WallsGen(1, transform);
        walls[4] = WallsGen(0, transform);
        walls[5] = WallsGen(1, transform);
        walls[6] = WallsGen(0, transform);
        walls[7] = WallsGen(1, transform);
        walls[8] = WallsGen(0, transform);
        walls[9] = WallsGen(1, transform);
        walls[10] = WallsGen(0, transform);
        walls[11] = WallsGen(1, transform);

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



