using UnityEngine;

public class FollowRocket : MonoBehaviour
{

    public static FollowRocket instance;
    public Transform Rocket;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (Rocket.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, Rocket.position.y, transform.position.z);
        }
    }

    public void ResetCamera()
    {
        transform.position = new Vector3(0, 0, -10);
    }
}
