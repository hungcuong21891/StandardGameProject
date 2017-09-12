using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppTrackerUnitySDK;
namespace BaseFramework{
	public class LeadboltProvider : AdProvider {
		private bool isInitialized = false;

		public void Init(){
			Debug.Log ("Leadbolt Init()");
			if (isInitialized) {
				return;
			}
			isInitialized = true;
			#if UNITY_ANDROID
			// Initialize Leadbolt SDK with your API Key
			AppTrackerAndroid.startSession(AdController.GetInstance().adProfileSetting.Leadbolt_ID, true);
			// listen to events
			AppTrackerAndroid.onModuleLoadedEvent += onModuleLoaded;
			AppTrackerAndroid.onModuleClosedEvent += onModuleClosed;
			AppTrackerAndroid.onModuleFailedEvent += onModuleFailed;
			AppTrackerAndroid.onModuleCachedEvent += onModuleCached;
			AppTrackerAndroid.onMediaFinishedEvent += onMediaFinished;
			#elif UNITY_IOS
			// Initialize Leadbolt SDK with your API Key
			AppTrackerIOS.startSession(AdController.GetInstance().adProfileSetting.Leadbolt_ID, true);
			// cache Leadbolt Ad without showing it
			AppTrackerIOS.loadModuleToCache("inapp");
			// listen to events
			AppTrackerIOS.onModuleLoadedEvent += onModuleLoaded;
			AppTrackerIOS.onModuleClosedEvent += onModuleClosed;
			AppTrackerIOS.onModuleFailedEvent += onModuleFailed;
			AppTrackerIOS.onModuleCachedEvent += onModuleCached;
			AppTrackerIOS.onMediaFinishedEvent += onMediaFinished;
			#endif

		}

		void onModuleLoaded(string placement) {
			// Add code here to pause game and/or all media including audio
		}

		void onModuleClosed(string placement) {
			// Add code here to resume game and/or all media including audio
		}

		void onModuleFailed(string placement, string error, bool cached) {
			if(cached) {
				
			} else {
				
			}
		}

		void onModuleCached(string placement) {
			// Add code if not auto-recaching for when loadModuleModuleToCache is successful
		}

		void onMediaFinished(bool viewCompleted) {
			if(viewCompleted) {
				// User finished watching the video successfully
				if (AdController.GetInstance ().currentVideoProvider.VideoProvider == VideoProvider.Leadbolt) {
					EventInfo eventInfo = new EventInfo ();
					eventInfo.eventBool.Add ("IsSucceeded", true);
					EventManager.TriggerEvent ("ProviderVideoFinished", eventInfo);
				}
			} else {
				// Video wasn't fully watched by the user.
			}
		}
		/// <summary>
		/// Loads the interstitial.
		/// </summary>
		public void LoadInterstitial() {
			if (!IsInterstitialReady) {
				#if UNITY_ANDROID
				// cache Leadbolt Video Ad without showing it
				AppTrackerAndroid.loadModuleToCache("inapp");
				#elif UNITY_IOS
				AppTrackerIOS.loadModuleToCache("inapp");
				#endif
			}
		}
		/// <summary>
		/// Shows the interstitial.
		/// </summary>
		public void ShowInterstitial() {
			if (IsInterstitialReady) {
				#if UNITY_ANDROID
				AppTrackerAndroid.loadModule ("inapp");
				#elif UNITY_IOS
				AppTrackerIOS.loadModule("inapp");
				#endif
			}
		}
		/// <summary>
		/// Gets a value indicating whether this instance is interstitial ready.
		/// </summary>
		/// <value>true</value>
		/// <c>false</c>
		public bool IsInterstitialReady {
			get {
				#if UNITY_ANDROID
				return AppTrackerAndroid.isAdReady("inapp");
				#elif UNITY_IOS
				return AppTrackerIOS.isAdReady("inapp");
				#else
				return false;
				#endif
			}
		}
		/// <summary>
		/// Loads the video.
		/// </summary>
		public void LoadVideo() {
			if (!IsVideoReady) {
				#if UNITY_ANDROID
				// cache Leadbolt Video Ad without showing it
				AppTrackerAndroid.loadModuleToCache("video");
				#elif UNITY_IOS
				AppTrackerIOS.loadModuleToCache("video");
				#endif
			}
		}
		/// <summary>
		/// Shows the video.
		/// </summary>
		public void ShowVideo() {
			if (IsVideoReady) {
				#if UNITY_ANDROID
				AppTrackerAndroid.loadModule ("video");
				#elif UNITY_IOS
				AppTrackerIOS.loadModule("video");
				#endif
			}
		}
		public bool IsVideoReady {
			get {
				#if UNITY_ANDROID
				return AppTrackerAndroid.isAdReady("video");
				#elif UNITY_IOS
				return AppTrackerIOS.isAdReady("video");
				#else
				return false;
				#endif
			}
		}
		/// <summary>
		/// Gets the interstitial provider.
		/// </summary>
		/// <value>The interstitial provider.</value>
		public InterstitialProvider InterstitialProvider {
			get {
				return InterstitialProvider.Leadbolt;
			}
		}
		/// <summary>
		/// Gets the video provider.
		/// </summary>
		/// <value>The video provider.</value>
		public VideoProvider VideoProvider {
			get {
				return VideoProvider.Leadbolt;
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
