using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace BaseFramework {
    /// <summary>
    /// Watch video button.
    /// </summary>
    public class WatchVideoButton : MonoBehaviour {
        /// <summary>
        /// The called event when success.
        /// </summary>
        [System.NonSerialized]
        public string calledEventWhenSuccess;
        /// <summary>
        /// The called event info.
        /// </summary>
        public EventInfo calledEventInfo;
        /// <summary>
        /// Sets the called event when success.
        /// </summary>
        /// <param name="value">Value.</param>
        public void SetCalledEventWhenSuccess(string value) {
            calledEventWhenSuccess = value;
        }
        /// <summary>
        /// Watchs the video.
        /// </summary>
        public void WatchVideo() {
            EventManager.StartListening("AdControllerVideoFinished", OnAdControllerVideoFinished);
            AdController.GetInstance().LoadVideo();
            gameObject.SetActive(false);
        }
        /// <summary>
        /// Raises the ad controller video finished event.
        /// </summary>
        /// <param name="eventInfo">Event info.</param>
        void OnAdControllerVideoFinished(EventInfo eventInfo) {
            EventManager.StopListening("AdControllerVideoFinished", OnAdControllerVideoFinished);
            EventManager.TriggerEvent(calledEventWhenSuccess, calledEventInfo);
        }
    }
}