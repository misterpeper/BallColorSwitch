using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public static Player instance;
	public float jumpForce = 10f;

	public Rigidbody2D sphere;
	public SpriteRenderer sr;

	public string currentColor;

    public Object StarAnimation;
    public Object Death;

	public Color colorblue;
	public Color coloryellow;
	public Color colorviolet;
    public Color colorred;

    private int LastColor;

    //Spawntimer;
    private float Timer;

	void Start ()
	{
		SetRandomColor ();
        instance = this;

        LastColor = 0;
	}

	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0)) 
		{
            if(MainMenuManager.instance.GameStarted && !MainMenuManager.instance.GamePaused)
            { 
			    sphere.velocity = Vector2.up * jumpForce;
                SoundManager.instance.PlayJumpSound();
            }
        }
        Timer -= Time.deltaTime;
	}

    //Invoke method
    void GameOver()
    {
        MainMenuManager.instance.GameOver();
    }

	void OnTriggerEnter2D (Collider2D col)
	{
        if (col.tag == this.gameObject.tag)
        {

        }

        else
        {
            if (col.tag == "yellow" || col.tag == "blue" || col.tag == "violet" || col.tag == "red" || col.tag == "Wall")
            {
                GameObject death = Instantiate(Death, this.transform.position, Quaternion.identity) as GameObject;
                death.transform.position = new Vector3(0f, transform.position.y, 0f);

                //Changes
                MainMenuManager.instance.GameStarted = false;
                Invoke("GameOver", 2.0f);
                Camera.main.GetComponent<CameraVibration>().SetTimer(1.5f);
                this.GetComponent<Rigidbody2D>().gravityScale = 0;
                this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<CircleCollider2D>().enabled = false;

                SoundManager.instance.GameOver();
            }

            if (col.tag == "ColorChanger") 
		    {
			    SetRandomColor ();
                col.gameObject.SetActive(false);
			    return;
		    }
		    if (col.tag == "CheckPoint") 
		    {
			    GameManager.instance.Score++;
                SoundManager.instance.PlayCoinSound();
                col.gameObject.SetActive(false);
                GameObject animation = Instantiate(StarAnimation, this.transform.position, Quaternion.identity) as GameObject;
                animation.transform.position = new Vector3(0f, transform.position.y -1.65f, 0f);
			    return;
		    }
            if (col.tag == "Spawner" && Timer<0)
            {
                col.transform.parent.parent.parent.GetComponent<EndlessLevelGeneration>().SpawnLevel(col.transform.position);
                Timer = 1f;
            }
            if (col.tag == "Floor")
            {

            }
            if (col.tag == "Finish")
            {
                SoundManager.instance.GameWin();
                MainMenuManager.instance.GameWon();
            }
        }
    }

	void SetRandomColor ()
	{
		int index = Random.Range(0, 4);

        while (index == LastColor)
        {
            index = Random.Range(0, 4);
        }

        LastColor = index;

		switch (index) 
		{
			case 0:
				currentColor = "blue";
                this.gameObject.tag = "blue";
                sr.color = colorblue;
				break;
			case 1:
				currentColor = "yellow";
                this.gameObject.tag = "yellow";
                sr.color = coloryellow;
				break;
			case 2:
				currentColor = "violet";
                this.gameObject.tag = "violet";
                sr.color = colorviolet;
				break;
			case 3:
				currentColor = "red";
                this.gameObject.tag = "red";
                sr.color = colorred;
				break;
		}

	}

    public void ResetPlayerPosition()
    {
        this.transform.position = new Vector3(0, -3.5f, 90);
        this.GetComponent<Rigidbody2D>().gravityScale = 3;
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<CircleCollider2D>().enabled = true;

        SetRandomColor();
    }
}
