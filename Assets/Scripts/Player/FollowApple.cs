using UnityEngine;

public class FollowApple : MonoBehaviour
{

    public static FollowApple instance;
    public Transform Apple;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (Apple.position.y < transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, Apple.position.y, transform.position.z);
        }
    }

    public void ResetCamera()
    {
        transform.position = new Vector3(0, 0, -10);
    }
}
