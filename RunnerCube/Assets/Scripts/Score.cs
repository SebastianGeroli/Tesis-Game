using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    /*################################  Variables ##################################*/
    public Player6x6 player;
    public Text ScoreText, BestText;
    float score;
    public float Multiplier = 1;

    /*################################  Getters && Setters  ##################################*/
    public float GetScore()
    {
        return score;
    }

    /*################################  Metodos  ##################################*/
    //Start
    void Start()
    {
        BestText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * 100 * Multiplier;
        score = (float)Math.Truncate(score);
        ScoreUpdate();
    }

    //Checkear si es mayor el score
    public void CheckScore() {
        if (float.Parse(ScoreText.text)>float.Parse(BestText.text)) {
            BestText.text = ScoreText.text;
        }
        score = 0;
    }

    //UpdateScore
    public void ScoreUpdate() {
        ScoreText.text = score.ToString();
    }
}
