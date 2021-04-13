using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    Text scoreText;

    void Start ()
    {
        scoreText = this.GetComponent<Text>();
	}
	
	void Update ()
    {
        scoreText.text = "" + GameManager.instance.Score.ToString();
    }
}
