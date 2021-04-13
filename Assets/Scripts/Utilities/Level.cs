using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public void ActivateLevel()
    {
        transform.GetChild(0).gameObject.SetActive(true);

        foreach (Transform child in transform.GetChild(0))
        {
            child.gameObject.SetActive(true);

            foreach (Transform child2 in child)
            {
                child2.gameObject.SetActive(true);
            }
        }
    }

    public void DeactivateLevel()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
