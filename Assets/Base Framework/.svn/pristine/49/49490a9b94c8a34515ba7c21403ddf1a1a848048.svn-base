#if UNITY_IOS || UNITY_ANDROID
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;

namespace BaseFramework {
    /// <summary>
    /// Unity ads provider.
    /// </summary>
    public class UnityAdsProvider : MonoBehaviour, AdProvider {
        /// <summary>
        /// The is interstitial ready.
        /// </summary>
        private bool isInterstitialReady = false;
        /// <summary>
        /// The is video ready.
        /// </summary>
        private bool isVideoReady = false;
        /// <summary>
        /// The options.
        /// </summary>
        private ShowOptions options;
        /// <summary>
        /// Create this instance.
        /// </summary>
        public static UnityAdsProvider Create() {
            GameObject g = new GameObject("UnityAdsProvider");
            g.transform.parent = AdController.GetInstance().gameObject.transform;
            return g.AddComponent<UnityAdsProvider>();
        }
        /// <summary>
        /// Init this instance.
        /// </summary>
        public void Init() {
            string appId = string.Empty;
            switch (Application.platform) {
                case RuntimePlatform.Android:
                    appId = AdController.GetInstance().adProfileSetting.UnityAds_Android_ID;
                    break;
                case RuntimePlatform.IPhonePlayer:
                    appId = AdController.GetInstance().adProfileSetting.UnityAds_IOS_ID;
                    break;
            }

            Debug.Log("UnityAdsProvider Init with appId: " + appId);

            Advertisement.Initialize(appId, false);
        }
        /// <summary>
        /// Fixeds the update.
        /// </summary>
        void FixedUpdate() {
            if (!isVideoReady) {
                OnVideoLoadEvent();
            }
        }
        /// <summary>
        /// Raises the video load event event.
        /// </summary>
        private void OnVideoLoadEvent() {
            if (AdController.GetInstance().currentVideoProvider.VideoProvider == VideoProvider.UnityAds) {
                if (Advertisement.IsReady()) {
                    Debug.Log("UnityAdsProvider Advertisement.IsReady()");

                    isVideoReady = true;

                    EventInfo eventInfo = new EventInfo();
                    eventInfo.eventBool.Add("IsLoaded", true);
                    EventManager.TriggerEvent("ProviderVideoLoadComplete", eventInfo);
                }
            }
        }
        /// <summary>
        /// Videos the finished.
        /// </summary>
        /// <param name="result">Result.</param>
        private void VideoFinished(ShowResult result) {
            if (AdController.GetInstance().currentVideoProvider.VideoProvider == VideoProvider.UnityAds) {
                Debug.Log("UnityAdsProvider VideoFinished() with result " + result.ToString());

                options.resultCallback -= VideoFinished;

                EventInfo eventInfo = new EventInfo();
                eventInfo.eventBool.Add("IsSucceeded", true);
                EventManager.TriggerEvent("ProviderVideoFinished", eventInfo);
            }
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
                return isInterstitialReady;
            }
        }
        /// <summary>
        /// Loads the video.
        /// </summary>
        public void LoadVideo() {
            Debug.Log("UnityAdsProvider LoadVideo()");

            OnVideoLoadEvent();
        }
        /// <summary>
        /// Shows the video.
        /// </summary>
        public void ShowVideo() {
            Debug.Log("UnityAdsProvider ShowVideo()");

            options = new ShowOptions();
            options.resultCallback += VideoFinished;

            Advertisement.Show(null, options);
            isVideoReady = false;
        }
        /// <summary>
        /// Gets a value indicating whether this instance is video ready.
        /// </summary>
        /// <value>true</value>
        /// <c>false</c>
        public bool IsVideoReady {
            get {
                return isVideoReady;
            }
            set {
                isVideoReady = value;
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
                return VideoProvider.UnityAds;
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
#endif