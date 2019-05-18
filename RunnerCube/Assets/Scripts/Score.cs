using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    /*################################  Variables ##################################*/
    public Player player;
    public Text ScoreText, BestText,MultiplierText;
    float score,bestScore;
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
        if ( DataController.control.bestScore != null )
        {
            BestText.text = DataController.control.bestScore;
            bestScore = float.Parse(BestText.text);
        }
        else
        {
            BestText.text = null;
            bestScore = 0;
        }
        score = 0;

    }
    //Updatea el score
    void UpdateScore() {
       
       
    }
    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * 100 * multiplier;
        score = (float) Math.Truncate(score);
        ScoreUpdate();
    }
    //
    private void FixedUpdate()
    {
        
    }

    //Checkear si es mayor el score
    public void CheckScore() {
        if ( score > bestScore )
        {
            BestText.text = score.ToString();
            DataController.control.bestScore = BestText.text;
        }
      
    }

    //UpdateScore
    public void ScoreUpdate() {
        ScoreText.text = score.ToString();
        MultiplierText.text = GetMulplier().ToString();
    }
}
