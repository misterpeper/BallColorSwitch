using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public static FollowPlayer instance;
    public Transform Player;

    private void Start()
    {
        instance = this;
    }

    void Update () 
	{
        if (Player.position.y > transform.position.y) 
		{
            transform.position = new Vector3 (transform.position.x, Player.position.y, transform.position.z);
		}
	}

    public void ResetCamera()
    {
        transform.position = new Vector3(0,0,-10);
    }
}
