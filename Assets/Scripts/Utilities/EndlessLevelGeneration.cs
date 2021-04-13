using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessLevelGeneration : MonoBehaviour
{
    public GameObject[] Easy, Medium, Hard;

    public void SpawnLevel(Vector3 position)
    {
        int random = Random.Range(0, Easy.Length);
        Instantiate(Easy[random], new Vector3(position.x, position.y+20, position.z), Quaternion.identity, transform.GetChild(0));
    }
}
