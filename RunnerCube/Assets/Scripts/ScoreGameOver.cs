using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGameOver : MonoBehaviour
{
    public Text Score;
    void Start()
    {
        Score.text = DataController.control.bestScore;
       
    }

}
