using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Player6x6 player;
    public Text ScoreText, BestText;
    float score;
    // Start is called before the first frame update
    void Start()
    {
        BestText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetVidas() <= 0) {
            CheckScore();
            score = 0;
        }
        score += Time.deltaTime * 10;
        ScoreUpdate();
    }
    //Checkear si es mayor el score
    public void CheckScore() {
        if (float.Parse(ScoreText.text)>float.Parse(BestText.text)) {
            BestText.text = ScoreText.text;
        }
    }
    //UpdateScore
    public void ScoreUpdate() {
        ScoreText.text = score.ToString();
    }
}
