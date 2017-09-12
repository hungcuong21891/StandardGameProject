using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BaseFramework{
	public class AppLovinProvider : AdProvider {
		private bool isInitialized = false;

		public void Init(){
			Debug.Log ("AppLovin Init()");
			if (isInitialized) {
				return;
			}
			isInitialized = true;
			#if UNITY_ANDROID
			AppLovin.SetSdkKey(AdController.GetInstance().adProfileSetting.AppLovin_ID);
			AppLovin.InitializeSdk();
			#elif UNITY_IPHONE
			AppLovin.SetSdkKey(AdController.GetInstance().adProfileSetting.AppLovin_ID);
			AppLovin.InitializeSdk();
			#endif
		}

		void onAppLovinEventReceived(string ev){
			// The format would be "REWARDAPPROVEDINFO|AMOUNT|CURRENCY"
			if (ev.Contains("REWARDAPPROVEDINFO")) {
				if (AdController.GetInstance ().currentVideoProvider.VideoProvider == VideoProvider.AppLovin) {
					EventInfo eventInfo = new EventInfo ();
					eventInfo.eventBool.Add ("IsSucceeded", true);
					EventManager.TriggerEvent ("ProviderVideoFinished", eventInfo);
				}
			}
			else if(ev.Contains("LOADEDREWARDED")) {
				// A rewarded video was successfully loaded.
				if (AdController.GetInstance ().currentVideoProvider.VideoProvider == VideoProvider.AppLovin) {
					EventInfo eventInfo = new EventInfo ();
					eventInfo.eventBool.Add ("IsLoaded", true);
					EventManager.TriggerEvent ("ProviderVideoLoadComplete", eventInfo);
				}
			}
			else if(ev.Contains("LOADREWARDEDFAILED")) {
				// A rewarded video failed to load.
				// A rewarded video was successfully loaded.
				if (AdController.GetInstance ().currentVideoProvider.VideoProvider == VideoProvider.AppLovin) {
					EventInfo eventInfo = new EventInfo ();
					eventInfo.eventBool.Add ("IsLoaded", false);
					EventManager.TriggerEvent ("ProviderVideoLoadComplete", eventInfo);
				}
			}
			else if(ev.Contains("HIDDENREWARDED")) {
				// A rewarded video has been closed.  Preload the next rewarded video.
				AppLovin.LoadRewardedInterstitial();
			}
		}

		/// <summary>
		/// Loads the interstitial.
		/// </summary>
		public void LoadInterstitial() {
			if (!IsInterstitialReady) {
				AppLovin.PreloadInterstitial ();
			}
		}
		/// <summary>
		/// Shows the interstitial.
		/// </summary>
		public void ShowInterstitial() {
			if (IsInterstitialReady) {
				AppLovin.ShowInterstitial ();
			}
		}
		/// <summary>
		/// Gets a value indicating whether this instance is interstitial ready.
		/// </summary>
		/// <value>true</value>
		/// <c>false</c>
		public bool IsInterstitialReady {
			get {
				return AppLovin.HasPreloadedInterstitial ();
			}
		}
		/// <summary>
		/// Loads the video.
		/// </summary>
		public void LoadVideo() {
			if (!IsVideoReady) {
				AppLovin.LoadRewardedInterstitial ();
			}
		}
		/// <summary>
		/// Shows the video.
		/// </summary>
		public void ShowVideo() {
			AppLovin.ShowRewardedInterstitial ();
		}
		public bool IsVideoReady {
			get {
				return AppLovin.IsIncentInterstitialReady();
			}
		}
		/// <summary>
		/// Gets the interstitial provider.
		/// </summary>
		/// <value>The interstitial provider.</value>
		public InterstitialProvider InterstitialProvider {
			get {
					return InterstitialProvider.AppLovin;
			}
		}
		/// <summary>
		/// Gets the video provider.
		/// </summary>
		/// <value>The video provider.</value>
		public VideoProvider VideoProvider {
			get {
				return VideoProvider.AppLovin;
			}
		}
		/// <summary>
		/// The avaliable platfroms.
		/// </summary>
		private List<RuntimePlatform> _AvaliablePlatfroms = new List<RuntimePlatform> { RuntimePlatform.Android, RuntimePlatform.IPhonePlayer };
		/// <summary>
		/// Gets the avaliable platfroms.
		/// </summary>
		/// <value>The avaliable platfroms.</value>
		public List<RuntimePlatform> AvaliablePlatfroms {
			get {
				return _AvaliablePlatfroms;
			}
		}
	}
}
