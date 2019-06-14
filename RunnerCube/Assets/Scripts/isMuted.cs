using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isMuted : MonoBehaviour
{
	AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
		audioSource = GetComponent<AudioSource>();
    }
	private void Update() {
		if( DataController.control.cambioSonido ) {
			if( DataController.control.mute ) {
				audioSource.mute = true;
				DataController.control.cambioSonido = false;
			} else {
				audioSource.mute = false;
				DataController.control.cambioSonido = false;
			}
		}
	}
}
