using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour {
	public bool LlegoDestino;
	public GameObject ObstaclesConstructor(int Obj,Transform invoker){
		GameObject gO;
		switch (Obj) {
		case 0:
			gO = Instantiate (Resources.Load ("HalfWallTop"), invoker.position + new Vector3 (0, 7, 0), Quaternion.identity) as GameObject;
			return gO;
		case 1:
			gO = Instantiate (Resources.Load ("HalfWallBottom"), invoker.position, Quaternion.identity) as GameObject;
			return gO;
		case 2:
			gO = Instantiate (Resources.Load ("HalfWallLeft"), invoker.position + new Vector3 (-3, 4, 0), Quaternion.identity) as GameObject;
			return gO;
		case 3:
			gO = Instantiate (Resources.Load ("HalfWallRight"), invoker.position + new Vector3 (3, 4, 0), Quaternion.identity)as GameObject;
			return gO;
		case 4:
			gO = Instantiate (Resources.Load ("3_4Top"), invoker.position + new Vector3 (0, 5, 0), Quaternion.identity) as GameObject;
			return gO;
		case 5:
			gO = Instantiate (Resources.Load ("3_4Bottom"), invoker.position + new Vector3 (0, 3, 0), Quaternion.identity) as GameObject;
			return gO;
		case 6:
			gO = Instantiate (Resources.Load ("3_4Left"), invoker.position + new Vector3 (-1, 4, 0), Quaternion.identity) as GameObject;
			return gO;
		case 7:
			gO = Instantiate (Resources.Load ("3_4Right"), invoker.position + new Vector3 (1, 4, 0), Quaternion.identity) as GameObject;
			return gO;
		case 8:
			gO = Instantiate (Resources.Load ("Hexagon"))as GameObject;
			Quaternion qt = gO.transform.rotation;
			gO.transform.position = invoker.position + new Vector3 (0, 4, 0);
			return gO;
		default: 
			gO = Instantiate (Resources.Load ("HalfWallTop"), invoker.position + new Vector3 (0, 7, 0), Quaternion.identity) as GameObject;
			return gO;
		}
	}
}
