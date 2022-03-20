using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    public Text endScore;
    public Score endScoreValue;

    private void Update()
    {
      endScore.text = endScoreValue.score.ToString();
    }

}
