using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary{
	public float xMin, xMax, yMin, yMax,zMin,zMax;
}
public class JoystickMove:MonoBehaviour {
	public Boundary boundary;
	public GameManagerRunner gameManagerRunner;
	public Joystick joystick;
	float horizontalMove;
	float verticalMove;
	public float sentivity;
	public Rigidbody rb;
	public float tiltz,tiltx;
	private float speed = 100;
	// Update is called once per frame
	private void Awake() {
		rb = gameObject.GetComponent<Rigidbody>();
	}
	void FixedUpdate() {
		if( !gameManagerRunner.pause ) {
			horizontalMove = joystick.Horizontal/sentivity;
			verticalMove = joystick.Vertical/sentivity;
			Vector3 movement = new Vector3( horizontalMove , verticalMove , 0f );
			rb.velocity = movement * speed;
				rb.position += new Vector3( horizontalMove , verticalMove , 0 );
			rb.position = new Vector3(
				Mathf.Clamp( rb.position.x , boundary.xMin , boundary.xMax ),
				Mathf.Clamp( rb.position.y , boundary.yMin , boundary.yMax),
				Mathf.Clamp( rb.position.z , boundary.zMin , boundary.zMax )
				);
			rb.rotation = Quaternion.Euler( rb.velocity.y * tiltx , 180 , rb.velocity.x * tiltz );
		}
		


	}
}
