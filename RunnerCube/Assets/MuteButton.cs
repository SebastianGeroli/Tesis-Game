using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
	DataController dataController;
	Button button;
    // Start is called before the first frame update
    void Awake()
    {
		button = GetComponent<Button>();
		button.onClick.AddListener( mute );
    }
	public void mute() {
		DataController.control.Mute();
	}
}
