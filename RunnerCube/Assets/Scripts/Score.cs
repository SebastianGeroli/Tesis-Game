using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    /*################################  Variables ##################################*/
    public Player6x6 player;
    public Text ScoreText, BestText,MultiplierText;
    float score;
    private float multiplier = 1;

    /*################################  Getters && Setters  ##################################*/
    public float GetScore()
    {
        return score;
    }
    public float GetMulplier() {
        return multiplier;
    }
    public void SetMultipier(float a) {
         multiplier = a;
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
      
    }
    //
    private void FixedUpdate()
    {
        score += Time.deltaTime * 100 * multiplier;
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
        MultiplierText.text = GetMulplier().ToString();
    }
}
