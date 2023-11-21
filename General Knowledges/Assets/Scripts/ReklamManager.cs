using System.Collections;
using System;
using GoogleMobileAds.Api;
using System.Collections.Generic;
using UnityEngine;

public class ReklamManager : MonoBehaviour
{
    public RewardedAd OdulluReklamim;
    public string AndroidRewardedAddID;
    public string İosOdulluReklamKimligi;
    string Reklamid;


    private void Start()
    {
        RequestOdulluReklam();
        
    }


    public void RequestOdulluReklam()
    {

#if UNITY_ANDROID
        Reklamid = AndroidRewardedAddID;
#elif UNITY_IPHONE
        Reklamid = İosOdulluReklamKimligi;
#else
                                Reklamid = "Tanımsız Platform";
#endif

        OdulluReklamim = new RewardedAd(Reklamid);

        
        OdulluReklamim.OnUserEarnedReward += VideoyuizlediOduluHaketti;



        AdRequest request = new AdRequest.Builder().Build();
        OdulluReklamim.LoadAd(request);
    }


    

    public void OdulluReklamgoster()
    {

        if (OdulluReklamim.IsLoaded())
        {
            OdulluReklamim.Show();

            RequestOdulluReklam();
        }
        
    }

  
    public void VideoyuizlediOduluHaketti(object sender, Reward args)
    {

        Debug.Log("ödül alındı");


    }
}
