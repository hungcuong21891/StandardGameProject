using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudienceNetwork;
namespace BaseFramework{
	public class FacebookProvider : AdProvider {
		private InterstitialAd interstitialAd;
		private bool isLoaded;
		private GameObject socialManager;
		public void Init(){
			socialManager = GameObject.Find ("SocialManager");
		}
		/// <summary>
		/// Loads the interstitial.
		/// </summary>
		public void LoadInterstitial() {

			// Create the interstitial unit with a placement ID (generate your own on the Facebook app settings).
			// Use different ID for each ad placement in your app.
			InterstitialAd interstitialAd = new InterstitialAd (AdController.GetInstance().adProfileSetting.FacebookPlacement_ID);
			this.interstitialAd = interstitialAd;
			this.interstitialAd.Register (socialManager);
			// Set delegates to get notified on changes or when the user interacts with the ad.
			this.interstitialAd.InterstitialAdDidLoad = (delegate() {
				Debug.Log ("Interstitial ad loaded.");
				this.isLoaded = true;
			});
			interstitialAd.InterstitialAdDidFailWithError = (delegate(string error) {
				Debug.Log ("Interstitial ad failed to load with error: " + error);
			});
			interstitialAd.InterstitialAdWillLogImpression = (delegate() {
				Debug.Log ("Interstitial ad logged impression.");
			});
			interstitialAd.InterstitialAdDidClick = (delegate() {
				Debug.Log ("Interstitial ad clicked.");
			});

			// Initiate the request to load the ad.
			this.interstitialAd.LoadAd ();
		}
		/// <summary>
		/// Shows the interstitial.
		/// </summary>
		public void ShowInterstitial() {
			if (this.isLoaded) {
				this.interstitialAd.Show ();
				this.isLoaded = false;
			}
		}
		/// <summary>
		/// Gets a value indicating whether this instance is interstitial ready.
		/// </summary>
		/// <value>true</value>
		/// <c>false</c>
		public bool IsInterstitialReady {
			get {
				return this.isLoaded;
			}
		}
		/// <summary>
		/// Loads the video.
		/// </summary>
		public void LoadVideo() {
			
		}
		/// <summary>
		/// Shows the video.
		/// </summary>
		public void ShowVideo() {
			
		}
		/// <summary>
		/// Gets a value indicating whether this instance is video ready.
		/// </summary>
		/// <value>true</value>
		/// <c>false</c>
		public bool IsVideoReady {
			get {
				return false;
			}
		}
		/// <summary>
		/// Gets the interstitial provider.
		/// </summary>
		/// <value>The interstitial provider.</value>
		public InterstitialProvider InterstitialProvider {
			get {
				return InterstitialProvider.Facebook;
			}
		}
		/// <summary>
		/// Gets the video provider.
		/// </summary>
		/// <value>The video provider.</value>
		public VideoProvider VideoProvider {
			get {
				return VideoProvider.None;
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
