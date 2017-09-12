using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds;
using GoogleMobileAds.Api;

namespace BaseFramework {
    /// <summary>
    /// Ad mob provider.
    /// </summary>
    public class AdMobProvider : AdProvider {
		/// <summary>
		/// The reward based video.
		/// </summary>
		private RewardBasedVideoAd rewardBasedVideo = null;
		/// <summary>
		/// The reward video I.
		/// </summary>
		private string rewardVideoId = string.Empty;
        /// <summary>
        /// The interstitial.
        /// </summary>
        private InterstitialAd interstitial = null;
        /// <summary>
        /// The interstitial identifier.
        /// </summary>
        private string interstitialId = string.Empty;
        /// <summary>
        /// The banner.
        /// </summary>
        private BannerView banner = null;
        /// <summary>
        /// The banner identifier.
        /// </summary>
        private string bannerId = string.Empty;
        /// <summary>
        /// The is banner show.
        /// </summary>
        private bool isBannerShow = false;
        /// <summary>
        /// Init this instance.
        /// </summary>
        public void Init() {
            switch (Application.platform) {
                case RuntimePlatform.Android:
                    interstitialId = AdController.GetInstance().adProfileSetting.Admob_Android_Interstisial_Id;
					rewardVideoId = AdController.GetInstance().adProfileSetting.Admob_Android_Video_Id;
                    break;
                case RuntimePlatform.IPhonePlayer:
                    interstitialId = AdController.GetInstance().adProfileSetting.Admob_IOS_Interstisial_Id;
					rewardVideoId = AdController.GetInstance().adProfileSetting.Admob_IOS_Video_Id;
                    break;
            }
			//init reward based video
			rewardBasedVideo = RewardBasedVideoAd.Instance;
			this.rewardBasedVideo.OnAdLoaded += this.HandleRewardBasedVideoLoaded;
			this.rewardBasedVideo.OnAdFailedToLoad += this.HandleRewardBasedVideoFailedToLoad;
			this.rewardBasedVideo.OnAdOpening += this.HandleRewardBasedVideoOpened;
			this.rewardBasedVideo.OnAdStarted += this.HandleRewardBasedVideoStarted;
			this.rewardBasedVideo.OnAdRewarded += this.HandleRewardBasedVideoRewarded;
			this.rewardBasedVideo.OnAdClosed += this.HandleRewardBasedVideoClosed;
			this.rewardBasedVideo.OnAdLeavingApplication += this.HandleRewardBasedVideoLeftApplication;
            Debug.Log("AdmobProvider Init with Interstitial Id: " + interstitialId);
        }
        /// <summary>
        /// Inits the banner.
        /// </summary>
        public void InitBanner() {
            switch (Application.platform) {
                case RuntimePlatform.Android:
                    bannerId = AdController.GetInstance().adProfileSetting.Admob_Android_Banner_Id;
                    break;
                case RuntimePlatform.IPhonePlayer:
                    bannerId = AdController.GetInstance().adProfileSetting.Admob_IOS_Banner_Id;
                    break;
            }
            Debug.Log("AdmobProvider Init with Banner Id: " + bannerId);
        }
		/// <summary>
		/// Requests the video.
		/// </summary>
		private void RequestVideo(){
			this.rewardBasedVideo.LoadAd(createAdRequest(), rewardVideoId);
		}
        /// <summary>
        /// Requests the banner.
        /// </summary>
        private void RequestBanner() {
            banner = new BannerView(bannerId, AdSize.SmartBanner, AdPosition.Top);
            banner.OnAdLoaded += HandleOnAdLoaded;
            banner.OnAdFailedToLoad += HandleOnAdFailedLoading;
            // Load the banner with the request.
            banner.LoadAd(createAdRequest());
        }
        /// <summary>
        /// Requests the interstitial.
        /// </summary>
        private void RequestInterstitial() {

            // Create an interstitial.
            interstitial = new InterstitialAd(interstitialId);
            // Register for ad events.
            interstitial.OnAdLoaded += HandleOnInterstitialLoaded;
            interstitial.OnAdFailedToLoad += HandleOnInterstitialFailedLoading;
            interstitial.OnAdClosed += HandleOnInterstitialClosed;

            // Load an interstitial ad.
            interstitial.LoadAd(createAdRequest());
        }
			
        /// <summary>
        /// Creates the ad request.
        /// </summary>
        /// <returns>The ad request.</returns>
        private AdRequest createAdRequest() {
            AdRequest request = new AdRequest.Builder().Build();

            foreach (GADTestDevice device in AdController.GetInstance().adProfileSetting.testDevices) {
                request.TestDevices.Add(device.ID);
            }

            return request;
        }
		/*-----------------------BANNER-----------------------*/
        /// <summary>
        /// Loads the banner.
        /// </summary>
        public void LoadBanner() {
            RequestBanner();
        }
        /// <summary>
        /// Shows the banner.
        /// </summary>
        public void ShowBanner() {
            if (banner != null && !isBannerShow) {
                isBannerShow = true;
                banner.Show();
            }
            AdController.GetInstance().isShowingBanner = true;
        }
        /// <summary>
        /// Hides the banner.
        /// </summary>
        public void HideBanner() {
            if (banner != null && isBannerShow) {
                isBannerShow = false;
                banner.Hide();
            }
            AdController.GetInstance().isShowingBanner = false;
        }
		/// <summary>
		/// Determines whether this instance is banner show.
		/// </summary>
		/// <returns><c>true</c> if this instance is banner show; otherwise, <c>false</c>.</returns>
		public bool IsBannerShow() {
			return isBannerShow;
		}
		/*-----------------------Interstitial-----------------------*/
        /// <summary>
        /// Loads the interstitial.
        /// </summary>
        public void LoadInterstitial() {
            if (!IsInterstitialReady) {
                RequestInterstitial();
            }
        }
        /// <summary>
        /// Shows the interstitial.
        /// </summary>
        public void ShowInterstitial() {
            if (IsInterstitialReady && interstitial != null) {
                interstitial.Show();
            }

        }
		/// <summary>
		/// Gets a value indicating whether this instance is interstitial ready.
		/// </summary>
		/// <value><c>true</c> if this instance is interstitial ready; otherwise, <c>false</c>.</value>
		public bool IsInterstitialReady {
			get {
				if (interstitial != null) {
					return interstitial.IsLoaded();
				} else {
					return false;
				}
			}
		}
		/*-----------------------Video-----------------------*/
        /// <summary>
        /// Loads the video.
        /// </summary>
        public void LoadVideo() {
			if (!IsVideoReady) {
				RequestVideo ();
			}
        }
        /// <summary>
        /// Shows the video.
        /// </summary>
        public void ShowVideo() {
			if (IsVideoReady && rewardBasedVideo != null) {
				rewardBasedVideo.Show ();
			}
        }
        /// <summary>
        /// Gets a value indicating whether this instance is video ready.
        /// </summary>
        /// <value><c>true</c> if this instance is video ready; otherwise, <c>false</c>.</value>
        public bool IsVideoReady {
			get {
				if (rewardBasedVideo != null) {
					return rewardBasedVideo.IsLoaded();
				} else {
					return false;
				}
			}
        }
       
        /// <summary>
        /// Gets the interstitial provider.
        /// </summary>
        /// <value>The interstitial provider.</value>
        public InterstitialProvider InterstitialProvider {
            get {
                return InterstitialProvider.AdMob;
            }
        }
        /// <summary>
        /// Gets the video provider.
        /// </summary>
        /// <value>The video provider.</value>
        public VideoProvider VideoProvider {
            get {
                return VideoProvider.Admob;
            }
        }
        /// <summary>
        /// The avaliable platfroms.
        /// </summary>
        private List<RuntimePlatform> _AvaliablePlatfroms = new List<RuntimePlatform> { RuntimePlatform.Android, RuntimePlatform.IPhonePlayer, RuntimePlatform.WP8Player };
        /// <summary>
        /// Gets the avaliable platfroms.
        /// </summary>
        /// <value>The avaliable platfroms.</value>
        public List<RuntimePlatform> AvaliablePlatfroms {
            get {
                return _AvaliablePlatfroms;
            }
        }
        /// <summary>
        /// Handles the on ad loaded.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="args">Arguments.</param>
        public void HandleOnAdLoaded(object sender, EventArgs args) {
            Debug.Log("Admob HandleBannerLoaded event received.");
            ShowBanner();
        }
        /// <summary>
        /// Handles the on ad failed loading.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="args">Arguments.</param>
        public void HandleOnAdFailedLoading(object sender, AdFailedToLoadEventArgs args) {
            Debug.Log("Admob HandleBannerFailedToLoad event received with message: " + args.Message);
            HideBanner();
        }
        /// <summary>
        /// Handles the on interstitial failed loading.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="args">Arguments.</param>
        public void HandleOnInterstitialFailedLoading(object sender, AdFailedToLoadEventArgs args) {
            if (AdController.GetInstance().currentInterstitialProvider.InterstitialProvider == InterstitialProvider.AdMob) {
                EventInfo eventInfo = new EventInfo();
                eventInfo.eventBool.Add("IsLoaded", false);
                EventManager.TriggerEvent("ProviderInterstitialLoadComplete", eventInfo);
                Debug.Log("Admob HandleInterstitialFailedToLoad event received with message: " + args.Message);
            }
        }
        /// <summary>
        /// Handles the on interstitial loaded.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="args">Arguments.</param>
        public void HandleOnInterstitialLoaded(object sender, EventArgs args) {
            if (AdController.GetInstance().currentInterstitialProvider.InterstitialProvider == InterstitialProvider.AdMob) {
                EventInfo eventInfo = new EventInfo();
                eventInfo.eventBool.Add("IsLoaded", true);
                EventManager.TriggerEvent("ProviderInterstitialLoadComplete", eventInfo);
                Debug.Log("Admob HandleInterstitialLoaded event received.");
            }
        }
        /// <summary>
        /// Handles the on interstitial closed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="args">Arguments.</param>
        public void HandleOnInterstitialClosed(object sender, EventArgs args) {
            if (AdController.GetInstance().currentInterstitialProvider.InterstitialProvider == InterstitialProvider.AdMob) {
                EventInfo eventInfo = new EventInfo();
                eventInfo.eventBool.Add("IsSucceeded", true);
                EventManager.TriggerEvent("ProviderInterstitialFinished", eventInfo);
                Debug.Log("Admob HandleInterstitialClosing event received.");
                interstitial = null;
            }
        }
		/// <summary>
		/// Handles the reward based video loaded.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
		{
			MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
			EventInfo eventInfo = new EventInfo();
			eventInfo.eventBool.Add("IsLoaded", true);
			EventManager.TriggerEvent("ProviderVideoLoadComplete", eventInfo);
		}
		/// <summary>
		/// Handles the reward based video failed to load.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
		{
			MonoBehaviour.print(
				"HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
			EventInfo eventInfo = new EventInfo();
			eventInfo.eventBool.Add("IsLoaded", false);
			EventManager.TriggerEvent("ProviderVideoLoadComplete", eventInfo);
		}
		/// <summary>
		/// Handles the reward based video opened.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
		{
			MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
		}
		/// <summary>
		/// Handles the reward based video started.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
		{
			MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
		}
		/// <summary>
		/// Handles the reward based video closed.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
		{
			MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
		}
		/// <summary>
		/// Handles the reward based video rewarded.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		public void HandleRewardBasedVideoRewarded(object sender, Reward args)
		{
			string type = args.Type;
			double amount = args.Amount;
			MonoBehaviour.print(
				"HandleRewardBasedVideoRewarded event received for " + amount.ToString() + " " + type);
			EventInfo eventInfo = new EventInfo();
			eventInfo.eventBool.Add("IsSucceeded", true);
			EventManager.TriggerEvent("ProviderVideoFinished", eventInfo);
		}
		/// <summary>
		/// Handles the reward based video left application.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
		{
			MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
		}
    }
}