using UnityEngine;
using System.Collections;

namespace BaseFramework {
    /// <summary>
    /// Update position UI.
    /// </summary>
    public class UpdatePositionUI : MonoBehaviour {
        /// <summary>
        /// The has changed position.
        /// </summary>
        private bool hasChangedPos = false;
        /// <summary>
        /// Awake this instance.
        /// </summary>
        void Awake() {
            EventManager.StartListening("LoadUIHasBanner", OnLoadUIHasBanner);
        }
        /// <summary>
        /// Start this instance.
        /// </summary>
        void Start() {
        }
        /// <summary>
        /// Update this instance.
        /// </summary>
        void Update() {

        }
        /// <summary>
        /// Raises the load user interface has banner event.
        /// </summary>
        /// <param name="eventInfo">Event info.</param>
        void OnLoadUIHasBanner(EventInfo eventInfo) {
            if (!hasChangedPos) {
                hasChangedPos = true;
                float deltaX;
                eventInfo.eventFloat.TryGetValue("deltaX", out deltaX);
                float deltaY;
                eventInfo.eventFloat.TryGetValue("deltaY", out deltaY);
                transform.position += new Vector3(deltaX, deltaY, 0);
            }
        }
    }
}