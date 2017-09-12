using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BaseFramework {
    /// <summary>
    /// Vungle provider.
    /// </summary>
    public class VungleProvider : AdProvider {
        /// <summary>
        /// Init this instance.
        /// </summary>
        public void Init() {
            Debug.Log("VungleAdProvider Init()");
            Vungle.onAdStartedEvent += onAdStartedEvent;
            Vungle.onAdEndedEvent += onAdEndedEvent;
            Vungle.onAdViewedEvent += onAdViewedEvent;
            Vungle.onCachedAdAvailableEvent += onCachedAdAvailableEvent;
            Vungle.init(AdController.GetInstance().adProfileSetting.Vungle_Android_ID, AdController.GetInstance().adProfileSetting.Vungle_IOS_ID);
            Debug.Log("Vungle intialized with IOS Id: " + AdController.GetInstance().adProfileSetting.Vungle_Android_ID);
            Debug.Log("Vungle intialized with Android ID: " + AdController.GetInstance().adProfileSetting.Vungle_Android_ID);
        }
        /// <summary>
        /// Ons the ad ended event.
        /// </summary>
        private void onAdEndedEvent() {
            if (AdController.GetInstance().currentVideoProvider.VideoProvider == VideoProvider.Vungle) {
                Debug.Log("VungleAdProvider VideoFinished onAdEndedEvent()");
                EventInfo eventInfo = new EventInfo();
                eventInfo.eventBool.Add("IsSucceeded", true);
                EventManager.TriggerEvent("ProviderVideoFinished", eventInfo);
            }
        }
        /// <summary>
        /// Ons the cached ad available event.
        /// </summary>
        private void onCachedAdAvailableEvent() {
            if (AdController.GetInstance().currentVideoProvider.VideoProvider == VideoProvider.Vungle) {
                Debug.Log("VungleAdProvider onCachedAdAvailableEvent");
                EventInfo eventInfo = new EventInfo();
                eventInfo.eventBool.Add("IsLoaded", true);
                EventManager.TriggerEvent("ProviderVideoLoadComplete", eventInfo);
            }
        }
        /// <summary>
        /// Ons the ad viewed event.
        /// </summary>
        /// <param name="watched">Watched.</param>
        /// <param name="length">Length.</param>
        private void onAdViewedEvent(double watched, double length) {
            Debug.Log("VungleAdProvider onAdViewedEvent. watched: " + watched + ", length: " + length);
        }
        /// <summary>
        /// Ons the ad started event.
        /// </summary>
        private void onAdStartedEvent() {
            Debug.Log("onAdStartedEvent");
        }
        /// <summary>
        /// Loads the interstitial.
        /// </summary>
        public void LoadInterstitial() {
        }
        /// <summary>
        /// Shows the interstitial.
        /// </summary>
        public void ShowInterstitial() {
        }
        /// <summary>
        /// Gets a value indicating whether this instance is interstitial ready.
        /// </summary>
        /// <value>true</value>
        /// <c>false</c>
        public bool IsInterstitialReady {
            get {
                return false;
            }
        }
        /// <summary>
        /// Loads the video.
        /// </summary>
        public void LoadVideo() {
            Debug.Log("VungleAdProvider LoadVideo()");

            if (IsVideoReady) {
                EventInfo eventInfo = new EventInfo();
                eventInfo.eventBool.Add("IsLoaded", true);
                EventManager.TriggerEvent("ProviderVideoLoadComplete", eventInfo);
            }
        }
        /// <summary>
        /// Shows the video.
        /// </summary>
        public void ShowVideo() {
            Debug.Log("VungleAdProvider ShowVideo()");

            Vungle.playAd();
        }
        /// <summary>
        /// Gets a value indicating whether this instance is video ready.
        /// </summary>
        /// <value>true</value>
        /// <c>false</c>
        public bool IsVideoReady {
            get {
                return Vungle.isAdvertAvailable();
            }
        }
        /// <summary>
        /// Gets the interstitial provider.
        /// </summary>
        /// <value>The interstitial provider.</value>
        public InterstitialProvider InterstitialProvider {
            get {
                return InterstitialProvider.None;
            }
        }
        /// <summary>
        /// Gets the video provider.
        /// </summary>
        /// <value>The video provider.</value>
        public VideoProvider VideoProvider {
            get {
                return VideoProvider.Vungle;
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