using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove:MonoBehaviour {
	public GameManagerRunner gameManagerRunner;
	public Joystick joystick;
	float horizontalMove;
	float verticalMove;
	public float sentivity;
	// Update is called once per frame
	void Update() {
		if( !gameManagerRunner.pause ) {
			horizontalMove = joystick.Horizontal/sentivity;
			verticalMove = joystick.Vertical/sentivity;
			if( transform.position.x <= 2.5f && transform.position.x >= -2.5f && transform.position.y >= 0 && transform.position.y <= 5 ) {
				transform.position += new Vector3( horizontalMove , verticalMove , 0 );
			} else if( transform.position.y > 5 ) {
				float x = transform.position.x;
				transform.position = new Vector3( x , 5 , 0 );
				transform.position += new Vector3( horizontalMove , 0 , 0 );
			} else if( transform.position.y < 0 ) {
				float x = transform.position.x;
				transform.position = new Vector3( x , 0 , 0 );
				transform.position += new Vector3( horizontalMove , 0 , 0 );
			} else if( transform.position.x > 2.5f ) {
				float y = transform.position.y;
				transform.position = new Vector3( 2.5f , y , 0 );
				transform.position += new Vector3( 0 , verticalMove , 0 );
			} else if( transform.position.x < -2.5f ) {
				float y = transform.position.y;
				transform.position = new Vector3( -2.5f , y , 0 );
				transform.position += new Vector3( 0 , verticalMove , 0 );
			}
		}

	}
}
