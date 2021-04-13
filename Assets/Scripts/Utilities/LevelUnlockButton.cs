using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlockButton : MonoBehaviour
{
    [SerializeField]
    private int LevelNumber;
    private Button btn;

	// Use this for initialization
	void Start ()
    {
        btn = this.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (LevelNumber <= GameManager.instance.MaxLevel)
        {
            btn.interactable = true;
        }
        else
        {
            btn.interactable = false;
        }
	}
}
