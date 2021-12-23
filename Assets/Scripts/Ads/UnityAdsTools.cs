using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Tools
{
    internal class UnityAdsTools : MonoBehaviour, IAdsShower
    {
        private const string _gameId = "4520967";
        private const string _bannerPlacementId = "Banner_Android";
        private const string _nterstitialId = "Interstitial_Android";

        private void Start()
        {
            Advertisement.Initialize(_gameId, true);
        }

        public void ShowBanner()
        {
            Advertisement.Show(_bannerPlacementId);
        }

        public void ShowInterstitial()
        {
            Advertisement.Show(_nterstitialId);
        }

    }
}