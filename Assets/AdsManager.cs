using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsListener
{

// #if UNITY_ANDROID
    string gameID = "5008981";
    string Interstitial = "Interstitial_Android";
    string Rewarded = "Rewarded_Android";
    string Banner = "Banner_Android";
// #else
//     string gameID = "5008980";
//     string Interstitial = "Interstitial_iOS";
//     string Rewarded = "Rewarded_iOS";
//     string Banner = "Banner_IOS";
// #endif

    BannerOptions banneroptions = new BannerOptions();
    BannerLoadOptions bannerLoadOptions = new BannerLoadOptions();
    ShowOptions showOptions = new ShowOptions();


    private void Start()
    {
        Advertisement.Initialize(
            gameId: gameID,
            testMode: true,
            enablePerPlacementLoad: true,
            initializationListener: this
        );

        Advertisement.AddListener(listener: this);

        banneroptions.showCallback += onshowBanner;
        banneroptions.showCallback += onHideBanner;
        banneroptions.showCallback += onClickBanner;
    }

    private void onDestroy()
    {
        banneroptions.showCallback -= onshowBanner;
        banneroptions.showCallback -= onHideBanner;
        banneroptions.showCallback -= onClickBanner;
    }

    public void ShowInterstitial()
    {
        Advertisement.Load(
            placementId: Interstitial,
            loadListener: this
        );

        Advertisement.Show(
            placementId: Interstitial,
            showOptions: showOptions,
            showListener: this
        );
    }

    public void ShowRewarded()
    {
        Advertisement.Load(
            placementId: Rewarded,
            loadListener: this
        );

        Advertisement.Show(
            placementId: Rewarded,
            showOptions: showOptions
        );
    }

    public void ShowBanner()
    {
        Advertisement.Banner.Load(Banner);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(
            placementId: Banner,
            options: banneroptions
        );
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide(false);
    }

    //-------------------Banner Callback--------------------//
    private void onshowBanner()
    {
        Debug.Log("onshowBanner");
    }
    private void onHideBanner()
    {
        Debug.Log("onHideBanner");
    }

    private void onClickBanner()
    {
        Debug.Log("onClickBanner");
    }

    //-------------------Initialization Callback--------------------//
    public void OnInitializationComplete()
    {
        // throw new System.NotImplementedException();
        Debug.Log("OnInitializationComplete");
        Advertisement.Load(
            placementId: Banner, 
            loadListener: this
        );
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        // throw new System.NotImplementedException();
        Debug.Log("OnInitializationFailed: [" + error + "]" + message);

    }

    //-------------------Load Callback--------------------//
    public void OnUnityAdsAdLoaded(string placementId)
    {
        // throw new System.NotImplementedException();
        Debug.Log("OnUnityAdsAdLoaded: " + placementId);

    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        // throw new System.NotImplementedException();
        Debug.Log("OnUnityAdsFailedToLoad: [" + placementId + "] [" + error + "] [" + message + "]");
    }

    //-------------------Show Callback--------------------//
    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("OnUnityAdsShowFailure: [" + placementId + "]");
        // throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("OnUnityAdsShowStart: [" + placementId + "]");
        // throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("OnUnityAdsShowClick: [" + placementId + "]");
        // throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("OnUnityAdsShowComplete: [" + placementId + "] [" + showCompletionState + "]");
        // throw new System.NotImplementedException();
    }

    //-------------------Show Callback--------------------//
    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("OnUnityAdsReady");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("OnUnityAdsDidError");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("OnUnityAdsDidStart");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Debug.Log("OnUnityAdsDidFinish");
    }
}
