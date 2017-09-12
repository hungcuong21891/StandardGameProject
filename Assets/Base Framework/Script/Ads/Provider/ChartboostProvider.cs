using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ChartboostSDK;

namespace BaseFramework {
    /// <summary>
    /// Chartboost provider.
    /// </summary>
    public class ChartboostProvider : AdProvider {
        /// <summary>
        /// The is initialized.
        /// </summary>
        private bool isInitialized = false;
        /// <summary>
        /// Init this instance.
        /// </summary>
        public void Init() {
            if (isInitialized) {
                return;
            }
            isInitialized = true;
            // Listen to all impression-related events
            //		Chartboost.Create();
            Debug.Log("ChartboostProvider Init()");
            //Interstitial
            Chartboost.didFailToLoadInterstitial += didFailToLoadInterstitial;
            Chartboost.didDismissInterstitial += didDismissInterstitial;
            Chartboost.didCacheInterstitial += didCacheInterstitial;
            //Video
            Chartboost.didFailToLoadRewardedVideo += didFailToLoadRewardedVideo;
            Chartboost.didDismissRewardedVideo += didDismissRewardedVideo;
            Chartboost.didCacheRewardedVideo += didCacheRewardedVideo;
            Chartboost.didCompleteRewardedVideo += didCompleteRewardedVideo;
        }
        /// <summary>
        /// Dids the cache interstitial.
        /// </summary>
        /// <param name="location">Location.</param>
        void didCacheInterstitial(CBLocation location) {
            if (AdController.GetInstance().currentInterstitialProvider.InterstitialProvider == InterstitialProvider.Chartboost) {
                EventInfo eventInfo = new EventInfo();
                eventInfo.eventBool.Add("IsLoaded", true);
                EventManager.TriggerEvent("ProviderInterstitialLoadComplete", eventInfo);
                Debug.Log("Chartboost: didCacheInterstitial");
            }
        }
        /// <summary>
        /// Dids the dismiss interstitial.
        /// </summary>
        /// <param name="location">Location.</param>
        void didDismissInterstitial(CBLocation location) {
            if (AdController.GetInstance().currentInterstitialProvider.InterstitialProvider == InterstitialProvider.Chartboost) {
                EventInfo eventInfo = new EventInfo();
                eventInfo.eventBool.Add("IsSucceeded", true);
                EventManager.TriggerEvent("ProviderInterstitialFinished", eventInfo);
                Debug.Log("Chartboost: didDismissInterstitial");
            }
        }
        /// <summary>
        /// Dids the fail to load interstitial.
        /// </summary>
        /// <param name="location">Location.</param>
        /// <param name="error">Error.</param>
        void didFailToLoadInterstitial(CBLocation location, CBImpressionError error) {
            if (AdController.GetInstance().currentInterstitialProvider.InterstitialProvider == InterstitialProvider.Chartboost) {
                EventInfo eventInfo = new EventInfo();
                eventInfo.eventBool.Add("IsLoaded", false);
                EventManager.TriggerEvent("ProviderInterstitialLoadComplete", eventInfo);
                Debug.Log(string.Format("Chartboost:  didFailToLoadInterstitial: {0} at location {1}", error, location));
            }
        }
        /// <summary>
        /// Dids the dismiss rewarded video.
        /// </summary>
        /// <param name="location">Location.</param>
        void didDismissRewardedVideo(CBLocation location) {
            if (AdController.GetInstance().currentVideoProvider.VideoProvider == VideoProvider.Chartboost) {
                EventInfo eventInfo = new EventInfo();
                eventInfo.eventBool.Add("IsSucceeded", true);
                EventManager.TriggerEvent("ProviderVideoFinished", eventInfo);
                Debug.Log("Chartboost: didDismissRewardedVideo");
            }
        }
        /// <summary>
        /// Dids the complete rewarded video.
        /// </summary>
        /// <param name="location">Location.</param>
        /// <param name="arg2">Arg2.</param>
        void didCompleteRewardedVideo(CBLocation location, int arg2) {
            if (AdController.GetInstance().currentVideoProvider.VideoProvider == VideoProvider.Chartboost) {
                Debug.Log("Chartboost: didCompleteRewardedVideo");
            }
        }
        /// <summary>
        /// Dids the fail to load rewarded video.
        /// </summary>
        /// <param name="location">Location.</param>
        /// <param name="error">Error.</param>
        void didFailToLoadRewardedVideo(CBLocation location, CBImpressionError error) {
            if (AdController.GetInstance().currentVideoProvider.VideoProvider == VideoProvider.Chartboost) {
                EventInfo eventInfo = new EventInfo();
                eventInfo.eventBool.Add("IsLoaded", false);
                EventManager.TriggerEvent("ProviderVideoLoadComplete", eventInfo);

                Debug.Log(string.Format("Chartboost: FailToLoad Rewarded Video: {0} at location {1}", error, location));
            }
        }
        /// <summary>
        /// Dids the cache rewarded video.
        /// </summary>
        /// <param name="location">Location.</param>
        void didCacheRewardedVideo(CBLocation location) {
            if (AdController.GetInstance().currentVideoProvider.VideoProvider == VideoProvider.Chartboost) {
                EventInfo eventInfo = new EventInfo();
                eventInfo.eventBool.Add("IsLoaded", true);
                EventManager.TriggerEvent("ProviderVideoLoadComplete", eventInfo);

                Debug.Log("Chartboost: didCacheRewardedVideo");
            }
        }
        /// <summary>
        /// Loads the interstitial.
        /// </summary>
        public void LoadInterstitial() {
            if (!IsInterstitialReady) {
                Debug.Log("Chartboost cacheInterstitial()");
                Chartboost.cacheInterstitial(CBLocation.Default);
            }
        }
        /// <summary>
        /// Shows the interstitial.
        /// </summary>
        public void ShowInterstitial() {
            if (IsInterstitialReady) {
                Chartboost.showInterstitial(CBLocation.Default);
            }
        }
        /// <summary>
        /// Gets a value indicating whether this instance is interstitial ready.
        /// </summary>
        /// <value>true</value>
        /// <c>false</c>
        public bool IsInterstitialReady {
            get {
                return Chartboost.hasInterstitial(CBLocation.Default);
            }
        }
        /// <summary>
        /// Loads the video.
        /// </summary>
        public void LoadVideo() {
            if (!IsVideoReady) {
                Debug.Log("Chartboost cacheRewardedVideo()");
                Chartboost.cacheRewardedVideo(CBLocation.Default);
            }
        }
        /// <summary>
        /// Shows the video.
        /// </summary>
        public void ShowVideo() {
            Chartboost.showRewardedVideo(CBLocation.Default);
        }
        /// <summary>
        /// Gets a value indicating whether this instance is video ready.
        /// </summary>
        /// <value>true</value>
        /// <c>false</c>
        public bool IsVideoReady {
            get {
                return Chartboost.hasRewardedVideo(CBLocation.Default);
            }
        }
        /// <summary>
        /// Gets the interstitial provider.
        /// </summary>
        /// <value>The interstitial provider.</value>
        public InterstitialProvider InterstitialProvider {
            get {
                return InterstitialProvider.Chartboost;
            }
        }
        /// <summary>
        /// Gets the video provider.
        /// </summary>
        /// <value>The video provider.</value>
        public VideoProvider VideoProvider {
            get {
                return VideoProvider.Chartboost;
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