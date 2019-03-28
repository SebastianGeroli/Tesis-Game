using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    public float minTime,maxTime;
    private int lastInvoked = 0;
    private float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        generator();
    }
    public void generator() {
        time += Time.deltaTime;
        if (lastInvoked == 0&& time>0.15f){
            Instantiate(Resources.Load("WhiteWalls"), transform.position, Quaternion.identity);
            lastInvoked = 1;
            time = 0;
        }
        else if(time>0.15f){
            Instantiate(Resources.Load("BlueWalls"), transform.position, Quaternion.identity);
            lastInvoked = 0;
            time = 0;
        }
        
    }
}
