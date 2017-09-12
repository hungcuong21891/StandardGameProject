using UnityEngine;
using System.Collections;

namespace BaseFramework {
    /// <summary>
    /// Pixel perfect camera.
    /// </summary>
    public class PixelPerfectCamera : MonoBehaviour {
        /// <summary>
        /// The scale.
        /// </summary>
        public static float scale = 1f;
        /// <summary>
        /// The pixels to units.
        /// </summary>
        public static float pixelsToUnits = 100f;
        /// <summary>
        /// The native resolution.
        /// </summary>
        public Vector2 nativeResolution = new Vector2(240, 160);
        /// <summary>
        /// Awake this instance.
        /// </summary>
        void Awake() {
            scale = 1f;
            pixelsToUnits = 100f;
            Debug.Log("Screen.height: " + Screen.height);
            Debug.Log("Screen.width: " + Screen.width);
            var camera = GetComponent<Camera>();
            if (camera.orthographic) {
                scale = Screen.height / nativeResolution.y; // compare between real resolution and design resolution
                pixelsToUnits *= scale;
                camera.orthographicSize = (Screen.height / 2.0f) / pixelsToUnits;
            }
        }
    }
}