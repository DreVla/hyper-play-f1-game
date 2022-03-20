using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreText;
    public Score endScoreValue;
    private float highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "High score: " + PlayerPrefs.GetFloat("Highscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(endScoreValue.score > PlayerPrefs.GetFloat("Highscore"))
        {
            highScoreText.text = "High score: " + endScoreValue.score.ToString();
            highScore = endScoreValue.score;
            PlayerPrefs.SetFloat("Highscore", highScore);
        }
        
    }
}
