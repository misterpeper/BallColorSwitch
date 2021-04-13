using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreUI : MonoBehaviour
{
    Text scoreText;

    void Start()
    {
        scoreText = this.GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "" + GameManager.instance.LevelHigh[GameManager.instance.CurrentLevel].ToString();
    }
}
