using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary{
	public float xMin, xMax, yMin, yMax,zMin,zMax;
}
public class JoystickMove:MonoBehaviour {
	/*################################  Variables  ##################################*/
	public Boundary boundary;
	public GameManagerRunner gameManagerRunner;
	public Joystick joystick;
	float horizontalMove;
	float verticalMove;
	public float sentivity;
	public Rigidbody rb;
	public float tiltz,tiltx;
	private float speed = .01f;
	/*################################  Metodos  ##################################*/
	private void Awake() {
		rb = gameObject.GetComponent<Rigidbody>();
	}
	void FixedUpdate() {
		if (!gameManagerRunner.pause)
		{
			horizontalMove = joystick.Horizontal / sentivity;
			verticalMove = joystick.Vertical / sentivity;
			// Dejar fijo la sensibilidad del joystick
			//horizontalMove = 0;
			//verticalMove = 0;
			//if (joystick.Horizontal > 0.3f)
			//{
			//	horizontalMove = 0.02f;
			//}
			//if (joystick.Horizontal < -0.3f)
			//{
			//	horizontalMove = -0.02f;
			//}
			//if (joystick.Vertical > 0.3f)
			//{
			//	verticalMove = 0.02f;
			//}
			//if (joystick.Vertical < -0.3f)
			//{
			//	verticalMove = -0.02f;
			//}
			// fin de sensibilidad fija
			Vector3 movement = new Vector3( horizontalMove , verticalMove , 0f );
			rb.velocity = movement * speed;
			rb.position = new Vector3(
				Mathf.Clamp( rb.position.x+horizontalMove , boundary.xMin , boundary.xMax ),
				Mathf.Clamp( rb.position.y+verticalMove , boundary.yMin , boundary.yMax),
				Mathf.Clamp( rb.position.z , boundary.zMin , boundary.zMax )
				);
			rb.rotation = Quaternion.Euler( rb.velocity.y * tiltx , 180 , rb.velocity.x * tiltz );
		}
		


	}
}
