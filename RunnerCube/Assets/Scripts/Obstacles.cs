using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {
    private int forma;
    public bool LlegoDestino = false;
    public bool PuedeSalir = false;
    public Vector3 posInicial;
    public Rigidbody rb;
    Obstacles obstaculo;
    public int GetForma() {
        return forma;
    }
    //Devolucion Vector3 de posInicial
    public Vector3 GetposInicial() {
        return posInicial;
    }
    //Start
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    private void FixedUpdate()
    {
        MoveFloor();
    }
    public void MoveFloor()
    {

        if (!LlegoDestino && PuedeSalir)
            rb.transform.Translate(0, 0, -0.5f);

    }
    //Metodo que instancia los objetos al inicio del juego 
    public  Obstacles(int Obj,Transform invoker){
        forma = Obj;
        GameObject gO;
        switch (Obj) {
		case 0:
			gO = Instantiate (Resources.Load ("HalfWallTop"), invoker.position + new Vector3 (0, 7, 0), Quaternion.identity) as GameObject;
                break;
                //posInicial = gO.GetComponent<Transform>();
                //posInicial = gO.transform.position;
   //             Debug.Log(posInicial);
			//return gO;
		case 1:
			gO = Instantiate (Resources.Load ("HalfWallBottom"), invoker.position, Quaternion.identity) as GameObject;
                break;
            case 2:
			gO = Instantiate (Resources.Load ("HalfWallLeft"), invoker.position + new Vector3 (-3, 4, 0), Quaternion.identity) as GameObject;
                break;
            case 3:
			gO = Instantiate (Resources.Load ("HalfWallRight"), invoker.position + new Vector3 (3, 4, 0), Quaternion.identity)as GameObject;
                break;
            case 4:
			gO = Instantiate (Resources.Load ("3_4Top"), invoker.position + new Vector3 (0, 5, 0), Quaternion.identity) as GameObject;
                break;
            case 5:
			gO = Instantiate (Resources.Load ("3_4Bottom"), invoker.position + new Vector3 (0, 3, 0), Quaternion.identity) as GameObject;
                break;
            case 6:
			gO = Instantiate (Resources.Load ("3_4Left"), invoker.position + new Vector3 (-1, 4, 0), Quaternion.identity) as GameObject;
                break;
            case 7:
			gO = Instantiate (Resources.Load ("3_4Right"), invoker.position + new Vector3 (1, 4, 0), Quaternion.identity) as GameObject;
                break;
            //case 8:
            //	gO = Instantiate (Resources.Load ("Hexagon"))as Object;
            //	Quaternion qt = gO.transform.rotation;
            //	gO.transform.position = invoker.position + new Vector3 (0, 4, 0);
            //	return gO;
            default: 
			gO = Instantiate (Resources.Load ("HalfWallTop"), invoker.position + new Vector3 (0, 7, 0), Quaternion.identity) as GameObject;
                break;
        }
       
        gO.GetComponent<Obstacles>().posInicial = gO.GetComponent<Transform>().position;
        Debug.Log(Obj);
        Debug.Log(gO.transform.position);
        Debug.Log(posInicial);
    }
    
}
