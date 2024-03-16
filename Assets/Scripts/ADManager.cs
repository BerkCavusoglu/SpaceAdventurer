using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ADManager : MonoBehaviour
{
    private BannerView bannerView;

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();
    }

    void RequestBanner()
    {
#if UNITY_ANDROID
        string reklamID = "ca-app-pub-5059084012020738/1353628393";
#else 
        string reklamID = "unexpected_platform";
#endif
        AdSize adSize = AdSize.Banner;
        this.bannerView = new BannerView(reklamID, adSize, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
    }
}
