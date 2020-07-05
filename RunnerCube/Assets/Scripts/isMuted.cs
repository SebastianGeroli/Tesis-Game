using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isMuted : MonoBehaviour
{
	private void Update() {
		if( DataController.control.mute ) {
			GetComponent<AudioSource>().mute = true;
			DataController.control.cambioSonido = false;
		} else {
			GetComponent<AudioSource>().mute = false;
			DataController.control.cambioSonido = false;
		}
	}
}
