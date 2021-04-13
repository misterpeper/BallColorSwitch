using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;


public class AdManager : MonoBehaviour
{
    public static AdManager instance;

    public bool RewardedAdReady;

    private int Counter = 0;

    //Banner AdMob
    private BannerView bannerView;
    private InterstitialAd interstitial;

    void Awake()
    {
        instance = this;
        //Initialize Unity advertisement
        Advertisement.Initialize("2684378");

        //
#if UNITY_ANDROID
        string appId = "ca-app-pub-1198839565974414~3958046565";
#elif UNITY_IPHONE
		    string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);
        RequestBanner();
        RequestInterstitial();
    }

    public void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-1198839565974414/1328121590";
#elif UNITY_IPHONE
		    string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    public void ShowBanner()
    {
        bannerView.Show();
    }

    public void HideBanner()
    {
        bannerView.Hide();
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9426803676698529/5761849373";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Load the interstitial with the request.
        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    // Returns an ad request
    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    // Update is called once per frame
    void Update()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            RewardedAdReady = true;
        }
        else
        {
            RewardedAdReady = false;
        }
    }

    //Revive ad
    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //MainMenuManager.instance.Revive();
                break;

            case ShowResult.Skipped:
                //MainMenuManager.instance.GameOver();
                break;

            case ShowResult.Failed:
                //MainMenuManager.instance.GameOver();
                break;
        }
    }

    //Lives ad
    public void ShowLivesAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResultLives };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResultLives(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //MenuManager.menu.ExtraLives();
                break;

            case ShowResult.Skipped:
                break;

            case ShowResult.Failed:
                break;
        }
    }

    //Coins ad
    public void ShowCoinsAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResultCoins };
            Advertisement.Show("rewardedVideo", options);
        }
    }
    private void HandleShowResultCoins(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //MenuManager.menu.ExtraMoney();
                break;

            case ShowResult.Skipped:
                break;

            case ShowResult.Failed:
                break;
        }
    }

    //Coins ad
    public void ShowDoubleAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResultDouble };
            Advertisement.Show("rewardedVideo", options);
        }
    }
    private void HandleShowResultDouble(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //MainMenuManager.instance.DoubleMoney();
                break;

            case ShowResult.Skipped:
                break;

            case ShowResult.Failed:
                break;
        }
    }


    public void ShowRewardedVideo()
    {
        if (Advertisement.IsReady("rewardedVideo"))
            ShowRewardedAd();
    }

    public void ShowInterstitialAd()
    {
        Counter++;

        if (Counter == 1)
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show();
            }
            else
            {
                if (interstitial.IsLoaded())
                {
                    interstitial.Show();
                }
            }
        }
        else if (Counter == 3)
        {
            Counter = 0;

            if (interstitial.IsLoaded())
            {
                interstitial.Show();
            }
            else
            {
                if (Advertisement.IsReady())
                {
                    Advertisement.Show();
                }
            }
        }
    }
}