using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCtrl : MonoBehaviour
{

    public AudioSource audio;
    private bool muted = false;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
		Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
		auth.SignOut();
        Application.Quit();
    }

    public void Mute()
    {
        if (!audio)
            return;

        if (muted)
            audio.volume = 1;
        else
            audio.volume = 0;

        muted = !muted;
    }

}
