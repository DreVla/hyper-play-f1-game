using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public float score = 0;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        score += Time.deltaTime * 40;
        score = (float)Math.Round(score);
    }
}
