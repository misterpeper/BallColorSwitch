using UnityEngine;
using UnityEngine.SceneManagement;


public class Rocket : MonoBehaviour
{
    public static Rocket instance;
    public float jumpForce = 10f;

    public Rigidbody2D rocket;
    public SpriteRenderer sr;

    public string currentColor;

    public Object StarAnimation;

    public Color colorblue;
    public Color coloryellow;
    public Color colorviolet;
    public Color colorred;

    //Spawntimer;
    private float Timer;

    void Start()
    {
        SetRandomColor();
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            if (MainMenuManager.instance.GameStarted && !MainMenuManager.instance.GamePaused)
            {
                rocket.velocity = Vector2.up * jumpForce;
                // SoundManager.instance.PlayJumpSound();
            }
        }
        Timer -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == this.gameObject.tag)
        {

        }

        else
        {
            if (col.tag == "yellow" || col.tag == "blue" || col.tag == "violet" || col.tag == "red" || col.tag == "Wall" || col.tag == "Asteroid")
            {
                MainMenuManager.instance.GameOver();
                SoundManager.instance.GameOver();
            }

            if (col.tag == "ColorChanger")
            {
                SetRandomColor();
                col.gameObject.SetActive(false);
                return;
            }
            if (col.tag == "CheckPoint")
            {
                GameManager.instance.Score++;
                SoundManager.instance.PlayCoinSound();
                col.gameObject.SetActive(false);
                GameObject animation = Instantiate(StarAnimation, this.transform.position, Quaternion.identity) as GameObject;
                animation.transform.position = new Vector3(0f, transform.position.y - 1.65f, 0f);
                return;
            }
            if (col.tag == "Spawner" && Timer < 0)
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

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

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

    public void ResetRocketPosition()
    {
        this.transform.position = new Vector3(0, -4.2f, 90);
    }
}
