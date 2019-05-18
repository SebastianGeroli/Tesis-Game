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
    double score;
    private float multiplier = 1;

    /*################################  Getters && Setters  ##################################*/
    public double GetScore()
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
        if ( PlayerPrefs.GetString("BestScore") != null )
        {
            BestText.text = PlayerPrefs.GetString("BestScore");
        }
        else
        {
            BestText.text = "0";
        }
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * 100 * multiplier;
        score = (double) Math.Truncate(score);
        ScoreUpdate();
    }
    //
    private void FixedUpdate()
    {
        
    }

    //Checkear si es mayor el score
    public void CheckScore() {
        double i, x;
        if ( double.TryParse(BestText.text , out i) && double.TryParse(ScoreText.text , out x) )
        {
            if ( i < x )
            {
                BestText.text = ScoreText.text;
                PlayerPrefs.SetString("BestScore" , BestText.text);
            }
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("Parse Failed");
            System.Diagnostics.Debug.WriteLine(BestText.text.Length);
            System.Diagnostics.Debug.WriteLine(ScoreText.text.Length);
            Debug.Log("Parse Failed");
            Debug.Log(BestText.text.Length);
            Debug.Log(ScoreText.text.Length);
        }
    }

    //UpdateScore
    public void ScoreUpdate() {
        ScoreText.text = score.ToString();
        MultiplierText.text = GetMulplier().ToString();
    }
}
