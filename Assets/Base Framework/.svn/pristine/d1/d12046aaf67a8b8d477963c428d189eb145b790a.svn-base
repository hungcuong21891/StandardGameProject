using UnityEngine;
using System.Collections;

namespace BaseFramework {
    /// <summary>
    /// Timer.
    /// </summary>
    public class Timer {
        /// <summary>
        /// The time elapsed.
        /// </summary>
        float _timeElapsed;
        /// <summary>
        /// The total time.
        /// </summary>
        float _totalTime;
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseFramework.Timer"/> class.
        /// </summary>
        /// <param name="timeToCountInSec">Time to count in sec.</param>
        public Timer(float timeToCountInSec) {
            _totalTime = timeToCountInSec;
        }
        /// <summary>
        /// Updates the and test.
        /// </summary>
        /// <returns><c>true</c>, if and test was updated, <c>false</c> otherwise.</returns>
        public bool UpdateAndTest() {
            _timeElapsed += Time.deltaTime;
            return _timeElapsed >= _totalTime;
        }
        /// <summary>
        /// Gets the elapsed.
        /// </summary>
        /// <value>The elapsed.</value>
        public float Elapsed {
            get {
                return Mathf.Clamp(_timeElapsed / _totalTime, 0, 1);
            }
        }
    }
    /// <summary>
    /// Flash screen.
    /// </summary>
    public class FlashScreen : MonoBehaviour {
        /// <summary>
        /// The pixel.
        /// </summary>
        private Texture2D pixel;
        /// <summary>
        /// The color.
        /// </summary>
        public Color color = Color.red;
        /// <summary>
        /// The start alpha.
        /// </summary>
        public float startAlpha = 0.0f;
        /// <summary>
        /// The max alpha.
        /// </summary>
        public float maxAlpha = 1.0f;
        /// <summary>
        /// The ramp up time.
        /// </summary>
        public float rampUpTime = 0.5f;
        /// <summary>
        /// The hold time.
        /// </summary>
        public float holdTime = 0.5f;
        /// <summary>
        /// The ramp down time.
        /// </summary>
        public float rampDownTime = 0.5f;
        /// <summary>
        /// FLASHSTAT.
        /// </summary>
        enum FLASHSTATE {
            OFF, UP, HOLD, DOWN
        }
        /// <summary>
        /// The timer.
        /// </summary>
        Timer timer;
        /// <summary>
        /// The state.
        /// </summary>
        FLASHSTATE state = FLASHSTATE.OFF;
        /// <summary>
        /// Start this instance.
        /// </summary>
        void Start() {
            pixel = new Texture2D(1, 1);
            color.a = startAlpha;
            pixel.SetPixel(0, 0, color);
            pixel.Apply();
            // for testing
            //TookDamage(new DamagePacket(1));
        }
        /// <summary>
        /// Update this instance.
        /// </summary>
        public void Update() {
            switch (state) {
                case FLASHSTATE.UP:
                    if (timer.UpdateAndTest()) {
                        state = FLASHSTATE.HOLD;
                        timer = new Timer(holdTime);
                    }
                    break;
                case FLASHSTATE.HOLD:
                    if (timer.UpdateAndTest()) {
                        state = FLASHSTATE.DOWN;
                        timer = new Timer(rampDownTime);
                    }
                    break;
                case FLASHSTATE.DOWN:
                    if (timer.UpdateAndTest()) {
                        state = FLASHSTATE.OFF;
                        timer = null;
                    }
                    break;
            }
        }
        /// <summary>
        /// Sets the pixel alpha.
        /// </summary>
        /// <param name="a">The alpha component.</param>
        private void SetPixelAlpha(float a) {
            color.a = a;
            pixel.SetPixel(0, 0, color);
            pixel.Apply();
        }
        /// <summary>
        /// Raises the GU event.
        /// </summary>
        public void OnGUI() {
            switch (state) {
                case FLASHSTATE.UP:
                    SetPixelAlpha(Mathf.Lerp(startAlpha, maxAlpha, timer.Elapsed));
                    break;
                case FLASHSTATE.DOWN:
                    SetPixelAlpha(Mathf.Lerp(maxAlpha, startAlpha, timer.Elapsed));
                    break;
            }
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), pixel);
        }
        /// <summary>
        /// Flash this instance.
        /// </summary>
        public void Flash() {
            timer = new Timer(rampUpTime);
            state = FLASHSTATE.UP;
        }

    }
}