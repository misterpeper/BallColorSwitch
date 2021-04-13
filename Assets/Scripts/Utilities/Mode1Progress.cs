using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mode1Progress : MonoBehaviour
{
    private Text txt;

	// Use this for initialization
	void Start ()
    {
        txt = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameManager.instance.MaxLevel <= 50)
        {
            txt.text = GameManager.instance.MaxLevel + " / 50";
        }
        else
        {
            txt.text = "50 / 50";
        }
	}
}
