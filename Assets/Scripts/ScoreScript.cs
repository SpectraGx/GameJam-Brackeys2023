using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreText, HiScoreText;
        public FloatVariable Score, HiScore;
        
    
    void Start()
    {
        if(Score.floatValue >= HiScore.floatValue)
        {
            HiScore.floatValue = Score.floatValue;
        }

    }
    void Update()
    {
        ScoreText.text = "SCORE: " + Score.floatValue;

        HiScoreText.text = "HI SCORE: " + HiScore.floatValue;
    }

}
