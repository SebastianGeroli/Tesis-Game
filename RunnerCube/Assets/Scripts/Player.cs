using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player:MonoBehaviour {
	public GameManagerRunner gameManager;
	/*################################  Variables  ##################################*/
	public bool aKeyWasPressed;
	public float velocidadDeMovimiento = 0.3f;
	public Text vidasText;
	private int vidas = 5;
	private float timer;
	public int GravityPos = 0;
	bool isJumping;
	Transform obstacle;
	/*################################  Getters && Setters  ##################################*/
	public int GetVidas() {
		return vidas;
	}

	public void SetVidas( int a ) {
		vidas = a;
	}

	/*################################  Metodos  ##################################*/
	//Update Vidas in Text
	public void VidasUpdate() {
		vidasText.text = GetVidas().ToString();
	}
	
	//Start 
	private void Start() {
		VidasUpdate();
	}
	//Trigger  || detecta si choca contra los obstaculos
	private void OnTriggerEnter( Collider other ) {
		obstacle = other.gameObject.GetComponent<Transform>();
		if( obstacle.tag == "Obstacle" || obstacle.tag == "Corner" ) {
			SetVidas( GetVidas() - 1 );
			VidasUpdate();
			//Debug.Log(string.Format("{0} vidas restantes" , vidas));
		} else if( obstacle.parent != null && obstacle.parent.tag == "Obstacle" || obstacle.parent != null && obstacle.parent.tag == "Corner" ) {

			SetVidas( GetVidas() - 1 );
			VidasUpdate();
			//Debug.Log(string.Format("{0} vidas restantes",vidas));
		}

	}
}
