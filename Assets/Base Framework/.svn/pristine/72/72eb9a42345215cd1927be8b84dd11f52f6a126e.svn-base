using UnityEngine;
using System.Collections;

namespace BaseFramework {
    /// <summary>
    /// Social manager.
    /// </summary>
    public class SocialManager : Singleton<SocialManager> {
		public string googlePlayStoreLink;
		public string appleStoreLink;

		/// <summary>
        /// The title
        /// </summary>
        private const string TITLE = "Title";
        /// <summary>
        /// The messages
        /// </summary>
        private const string MESSAGE = "Message";
        /// <summary>
        /// Initialize this instance.
        /// </summary>
		/// 
        protected override void Initialize() {

        }
        /// <summary>
        /// Raises the rate button click event.
        /// </summary>
        public void OnRateButtonClick() {
            //TODO: put this on configuration
#if UNITY_ANDROID
			Application.OpenURL(googlePlayStoreLink);
#elif UNITY_IPHONE
			Application.OpenURL(appleStoreLink);
#endif
        }
        /// <summary>
        /// Shares the screen shot.
        /// </summary>
        public void shareScreenShot() {
            StartCoroutine(FrispGames.Social.ScreenshotSharer.Instance().PostScreenshot(TITLE, MESSAGE));
        }
    }
}