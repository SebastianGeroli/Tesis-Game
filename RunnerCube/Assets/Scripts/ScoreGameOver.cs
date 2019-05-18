using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGameOver : MonoBehaviour
{
    public Text Score;
    void Update()
    {
        if ( PlayerPrefs.GetString("BestScore") != null )
        {
            Score.text = PlayerPrefs.GetString("BestScore");
        }
        else
        {
            Score.text = "0";
        }
       
    }

}
