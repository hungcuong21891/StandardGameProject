using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BaseFramework {
    /// <summary>
    /// Ad provider.
    /// </summary>
    public interface AdProvider {
        /// <summary>
        /// Init this instance.
        /// </summary>
        void Init();
        /// <summary>
        /// Loads the interstitial.
        /// </summary>
        void LoadInterstitial();
        /// <summary>
        /// Shows the interstitial.
        /// </summary>
        void ShowInterstitial();
        /// <summary>
        /// Gets a value indicating whether this instance is interstitial ready.
        /// </summary>
        /// <value><c>true</c> if this instance is interstitial ready; otherwise, <c>false</c>.</value>
        bool IsInterstitialReady {
            get;
        }
        /// <summary>
        /// Loads the video.
        /// </summary>
        void LoadVideo();
        /// <summary>
        /// Shows the video.
        /// </summary>
        void ShowVideo();
        /// <summary>
        /// Gets a value indicating whether this instance is video ready.
        /// </summary>
        /// <value><c>true</c> if this instance is video ready; otherwise, <c>false</c>.</value>
        bool IsVideoReady {
            get;
        }
        /// <summary>
        /// Gets the interstitial provider.
        /// </summary>
        /// <value>The interstitial provider.</value>
        InterstitialProvider InterstitialProvider {
            get;
        }
        /// <summary>
        /// Gets the video provider.
        /// </summary>
        /// <value>The video provider.</value>
        VideoProvider VideoProvider {
            get;
        }
        /// <summary>
        /// Gets the avaliable platfroms.
        /// </summary>
        /// <value>The avaliable platfroms.</value>
        List<RuntimePlatform> AvaliablePlatfroms {
            get;
        }
    }
}