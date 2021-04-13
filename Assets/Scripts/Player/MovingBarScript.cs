using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBarScript : MonoBehaviour {

    public float speed = 3f;
    public float rangeMax = 10f;
    public float direction = 1f;
    public float initialPosotionX;

    private void Start()
    {
        initialPosotionX = this.transform.position.x;
    }

    // Update is called once per frame
    void Update () 
    {
        this.transform.position = new Vector2(
            this.transform.position.x + (direction * Time.deltaTime * speed), this.transform.position.y);
        if (this.transform.position.x > initialPosotionX + rangeMax) 
        {
            direction = -1;
        }
        if (this.transform.position.x < initialPosotionX - rangeMax)
        {
            direction = 1;
        }
    }
}
