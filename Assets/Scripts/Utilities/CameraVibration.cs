using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVibration : MonoBehaviour
{
    //Shake
    public float ShakeTimer, ShakeAmount;
    private Vector3 initialPos;

    // Use this for initialization
    void Start ()
    {
        initialPos = this.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (ShakeTimer > 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * ShakeAmount;
            transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + (ShakePos.y / 4), transform.position.z);
            ShakeTimer -= Time.deltaTime;
        }
        else
        {
            //transform.position = Vector3.Lerp(this.transform.position, initialPos, 0.05f);
        }
    }

    public void SetTimer(float time)
    {
        ShakeTimer = time;
    }
}
