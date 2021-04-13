using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    //Menu static reference
    public static MainMenuManager instance;

    //UI elements
    public GameObject MenuUI, GameUI, PauseUI, GameOverUI, ShopUI, EndlessSelection, GameModesSelection, Hand, WinUI;

    //Levels
    public GameObject Mode1, Mode2, Mode3, Mode4, Mode5, Mode6, Mode7, Mode8, Mode9, Mode10;

    //Player
    public GameObject[] Players;

    //Game flow bools
    public bool GameStarted, GamePaused;

    //Active level reference
    public Level level;
    //public Transform ;

    public GameObject cam;

    // Use this for initialization
    void Start()
    {
        //Set instance to this object
        instance = this;
        GameStarted = false;
        GamePaused = false;

        //Activate menu UI and turn off all others
        MenuUI.SetActive(true);
        GameUI.SetActive(false);
        PauseUI.SetActive(false);
        ShopUI.SetActive(false);
        ShopUI.SetActive(false);
        EndlessSelection.SetActive(false);
        GameModesSelection.SetActive(false);

        //Deactivate hand and players
        Hand.SetActive(false);
        foreach (GameObject player in Players)
        {
            player.SetActive(false);
        }

        WinUI.SetActive(false);

        GameManager.instance.Load();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStarted)
        {
            if (!GamePaused)
            {
                AdManager.instance.ShowBanner();
            }
            else
                AdManager.instance.HideBanner();
        }
        else
            AdManager.instance.HideBanner();
    }

    //Load one of the levels from the first mod
    public void LoadMode1()
    {
        Mode1.SetActive(true);
    }
    public void LoadMode2()
    {
        Mode2.SetActive(true);
    }
    public void LoadMode3()
    {
        Mode3.SetActive(true);
    }
    public void LoadMode4()
    {
        Mode4.SetActive(true);
    }
    public void LoadMode5()
    {
        Mode5.SetActive(true);
    }
    public void LoadMode6()
    {
        Mode6.SetActive(true);
    }
    public void LoadMode7()
    {
        Mode7.SetActive(true);
    }
    public void LoadMode8()
    {
        Mode8.SetActive(true);
    }
    public void LoadMode9()
    {
        Mode9.SetActive(true);
    }
    public void LoadMode10()
    {
        Mode10.SetActive(true);
    }

    public void StartLevel(int lvl)
    {
        GameManager.instance.LastLevel = lvl;
        GameManager.instance.Save();
        LoadLevel();
    }

    public void ShowClassicModes()
    {
        GameModesSelection.SetActive(true);
        Mode1.SetActive(false); Mode2.SetActive(false); Mode3.SetActive(false); Mode4.SetActive(false); Mode5.SetActive(false); Mode6.SetActive(false); Mode7.SetActive(false); Mode8.SetActive(false); Mode9.SetActive(false); Mode10.SetActive(false);
    }
    public void ShowEndlessModes()
    {
        EndlessSelection.SetActive(true);
    }


    //Load the last played or chosen level
    public void LoadLevel()
    {
        if (GameManager.instance.LastLevel == 0)
        {
            GameManager.instance.LastLevel = 1;
        }

        string lastLVL = GameManager.instance.LastLevel.ToString();
        level = GameObject.Find(lastLVL).GetComponent<Level>();
        level.ActivateLevel();
        StartGame();
    }

    public void NextLevel()
    {
        GameManager.instance.LastLevel++;
        GameManager.instance.Save();

        string lastLVL = GameManager.instance.LastLevel.ToString();

        level = GameObject.Find(lastLVL).GetComponent<Level>();
        level.ActivateLevel();
        StartGame();
    }

    public void StartGame()
    {
        GameManager.instance.Load();

        //Choose what player is activated
        if (GameManager.instance.LastLevel <= 50)
        {
            Hand.SetActive(true);
            Players[0].SetActive(true);

            //Tweak camera
            cam.GetComponent<FollowPlayer>().enabled = true;
            cam.GetComponent<FollowApple>().enabled = false;
            cam.GetComponent<FollowRocket>().enabled = false;
        }
        else if (GameManager.instance.LastLevel > 50 && GameManager.instance.LastLevel <= 100)
        {
            Players[1].SetActive(true);

            //Tweak camera
            cam.GetComponent<FollowPlayer>().enabled = false;
            cam.GetComponent<FollowRocket>().enabled = true;
            cam.GetComponent<FollowApple>().enabled = false;
        }
        else if (GameManager.instance.LastLevel > 100 && GameManager.instance.LastLevel <= 150)
        {
            Players[2].SetActive(true);

            //Tweak camera
            cam.GetComponent<FollowPlayer>().enabled = false;
            cam.GetComponent<FollowRocket>().enabled = false;
            cam.GetComponent<FollowApple>().enabled = true;
        }
        else if (GameManager.instance.LastLevel > 150 && GameManager.instance.LastLevel <= 200)
        {
            Players[3].SetActive(true);

            //Tweak camera
            cam.GetComponent<FollowPlayer>().enabled = false;
            cam.GetComponent<FollowRocket>().enabled = false;
            cam.GetComponent<FollowApple>().enabled = false;

        }
        else if (GameManager.instance.LastLevel > 200 && GameManager.instance.LastLevel <= 250)
        {
            Players[4].SetActive(true);
        }
        else if (GameManager.instance.LastLevel > 250 && GameManager.instance.LastLevel <= 300)
        {
            Players[5].SetActive(true);
        }
        else if (GameManager.instance.LastLevel > 300 && GameManager.instance.LastLevel <= 350)
        {
            Players[5].SetActive(true);
        }
        else if (GameManager.instance.LastLevel > 350 && GameManager.instance.LastLevel <= 400)
        {
            Players[6].SetActive(true);
        }
        else if (GameManager.instance.LastLevel > 400 && GameManager.instance.LastLevel <= 450)
        {
            Players[7].SetActive(true);
        }
        else if (GameManager.instance.LastLevel > 450 && GameManager.instance.LastLevel <= 500)
        {
            Players[8].SetActive(true);
        }
        else if (GameManager.instance.LastLevel > 500)
        {
            Players[9].SetActive(true);
        }

        //Rocket.SetActive(true);

        MenuUI.SetActive(false);
        EndlessSelection.SetActive(false);
        GameModesSelection.SetActive(false);
        GameOverUI.SetActive(false);
        WinUI.SetActive(false);

        GameUI.SetActive(true);

        GameManager.instance.Score = 0;
        Time.timeScale = 1;
        GamePaused = false;
        GameStarted = true;

        SoundManager.instance.PlaySoundtrack();
    }
    public void Pause()
    {
        GameUI.SetActive(false);
        PauseUI.SetActive(true);
        Time.timeScale = 0;
        GamePaused = true;
    }
    public void ResumeGame()
    {
        GameUI.SetActive(true);
        PauseUI.SetActive(false);
        Time.timeScale = 1;
        GamePaused = false;
    }
    public void GameOver()
    {
        GameStarted = false;
        Handheld.Vibrate();
        Invoke("Over", 0.1f);
    }
    private void Over()
    {
        level.DeactivateLevel();

        //Reset camera and player position
        //Choose what player is activated
        if (GameManager.instance.LastLevel <= 50)
        {
            Player.instance.ResetPlayerPosition();
            FollowPlayer.instance.ResetCamera();
        }
        else if (GameManager.instance.LastLevel > 50 && GameManager.instance.LastLevel <= 100)
        {
            Rocket.instance.ResetRocketPosition();
            FollowRocket.instance.ResetCamera();
        }
        else if (GameManager.instance.LastLevel > 100 && GameManager.instance.LastLevel <= 150)
        {
            Apple.instance.ResetApplePosition();
            FollowApple.instance.ResetCamera();
        }
        else if (GameManager.instance.LastLevel > 150 && GameManager.instance.LastLevel <= 200)
        {

        }
        else if (GameManager.instance.LastLevel > 200 && GameManager.instance.LastLevel <= 250)
        {

        }
        else if (GameManager.instance.LastLevel > 250 && GameManager.instance.LastLevel <= 300)
        {

        }
        else if (GameManager.instance.LastLevel > 300 && GameManager.instance.LastLevel <= 350)
        {

        }
        else if (GameManager.instance.LastLevel > 350 && GameManager.instance.LastLevel <= 400)
        {

        }
        else if (GameManager.instance.LastLevel > 400 && GameManager.instance.LastLevel <= 450)
        {

        }
        else if (GameManager.instance.LastLevel > 450 && GameManager.instance.LastLevel <= 500)
        {

        }
        else if (GameManager.instance.LastLevel > 500)
        {

        }

        GameOverUI.SetActive(true);
        AdManager.instance.ShowInterstitialAd();
        GameUI.SetActive(false);

        //Deactivate hand and players
        Hand.SetActive(false);
        foreach (GameObject player in Players)
        {
            player.SetActive(false);
        }

        GameManager.instance.Coins += GameManager.instance.Score;
        GameManager.instance.Save();
    }

    public void GameWon()
    {
        GameStarted = false;
        Handheld.Vibrate();
        Invoke("Won", 0.1f);
    }
    private void Won()
    {
        level.DeactivateLevel();

        //Reset camera and player position
        //Choose what player is activated
        if (GameManager.instance.LastLevel <= 50)
        {
            Player.instance.ResetPlayerPosition();
            FollowPlayer.instance.ResetCamera();
        }
        else if (GameManager.instance.LastLevel > 50 && GameManager.instance.LastLevel <= 100)
        {
            Rocket.instance.ResetRocketPosition();
            FollowRocket.instance.ResetCamera();
        }
        else if (GameManager.instance.LastLevel > 100 && GameManager.instance.LastLevel <= 150)
        {
            Apple.instance.ResetApplePosition();
            FollowApple.instance.ResetCamera();
        }
        else if (GameManager.instance.LastLevel > 150 && GameManager.instance.LastLevel <= 200)
        {

        }
        else if (GameManager.instance.LastLevel > 200 && GameManager.instance.LastLevel <= 250)
        {

        }
        else if (GameManager.instance.LastLevel > 250 && GameManager.instance.LastLevel <= 300)
        {

        }
        else if (GameManager.instance.LastLevel > 300 && GameManager.instance.LastLevel <= 350)
        {

        }
        else if (GameManager.instance.LastLevel > 350 && GameManager.instance.LastLevel <= 400)
        {

        }
        else if (GameManager.instance.LastLevel > 400 && GameManager.instance.LastLevel <= 450)
        {

        }
        else if (GameManager.instance.LastLevel > 450 && GameManager.instance.LastLevel <= 500)
        {

        }
        else if (GameManager.instance.LastLevel > 500)
        {

        }

        WinUI.SetActive(true);
        GameUI.SetActive(false);

        //Deactivate hand and players
        Hand.SetActive(false);
        foreach (GameObject player in Players)
        {
            player.SetActive(false);
        }

        GameManager.instance.Coins += GameManager.instance.Score;
        GameManager.instance.Save();
    }

    public void Restart()
    {
        GameStarted = false;
        Time.timeScale = 1;
        GameUI.SetActive(true);
        MenuUI.SetActive(false);
        PauseUI.SetActive(false);
        GameOverUI.SetActive(false);
        GameStarted = true;
        GamePaused = false;
        CancelInvoke();
    }

    public void Shop()
    {
        ShopUI.SetActive(true);
        MenuUI.SetActive(false);
    }

    public void Leaderboard()
    {

    }

    public void BackToMenu()
    {
        level.DeactivateLevel();

        //Deactivate hand and players
        Hand.SetActive(false);
        foreach (GameObject player in Players)
        {
            player.SetActive(false);
        }

        GameUI.SetActive(false);
        WinUI.SetActive(false);
        ShopUI.SetActive(false);
        MenuUI.SetActive(true);
        GameModesSelection.SetActive(false);
        EndlessSelection.SetActive(false);
        GameManager.instance.Score = 0;
        SoundManager.instance.PlaySoundtrack();
    }

    //Open settings
    public void LoadMenu()
    {
        level.DeactivateLevel();
        Time.timeScale = 1;
        MenuUI.SetActive(true);
        GameManager.instance.Save();
        GameStarted = false;
        GamePaused = false;

        GameUI.SetActive(false);
        ShopUI.SetActive(false);
        GameOverUI.SetActive(false);
        PauseUI.SetActive(false);

        //Deactivate hand and players
        Hand.SetActive(false);
        foreach (GameObject player in Players)
        {
            player.SetActive(false);
        }

        WinUI.SetActive(false);
        SoundManager.instance.PlaySoundtrack();
    }

    public void MoreGames()
    {
        Application.OpenURL("https://play.google.com/store/apps/developer?id=J2ml+Infotech");
    }

    public void RateApp()
    {
        Application.OpenURL("market://details?id=com.j2mlinfotech.aircommander");
    }
}
