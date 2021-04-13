using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mode2Progress : MonoBehaviour
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
        if (GameManager.instance.MaxLevel-50 <= 0)
        {
            txt.text = "0 / 50";
        }
        else if (GameManager.instance.MaxLevel-50 > 0 && GameManager.instance.MaxLevel - 50 <= 50)
        {
            txt.text = GameManager.instance.MaxLevel-50 + " / 50";
        }
        else if (GameManager.instance.MaxLevel - 50 >= 50)
        {
            txt.text = "50 / 50";
        }
	}
}
