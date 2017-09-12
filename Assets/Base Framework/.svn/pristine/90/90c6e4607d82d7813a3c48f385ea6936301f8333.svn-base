using UnityEngine;
using System.Collections;

namespace BaseFramework {
    /// <summary>
    /// Camera shake.
    /// </summary>
    public class CameraShake : MonoBehaviour {
        /// <summary>
        /// The shake amount.
        /// </summary>
        public float shakeAmount;
        /// <summary>
        /// The duration of the shake.
        /// </summary>
        public float shakeDuration;
        /// <summary>
        /// The shake percentage.
        /// </summary>
        float shakePercentage;
        /// <summary>
        /// The start amount.
        /// </summary>
        float startAmount;
        /// <summary>
        /// The start duration.
        /// </summary>
        float startDuration;
        /// <summary>
        /// The is running.
        /// </summary>
        bool isRunning = false;
        /// <summary>
        /// The smooth.
        /// </summary>
        public bool smooth;
        /// <summary>
        /// The smooth amount.
        /// </summary>
        public float smoothAmount = 5f;
        /// <summary>
        /// Start this instance.
        /// </summary>
        void Start() {
        }
        /// <summary>
        /// Shakes the camera.
        /// </summary>
        void ShakeCamera() {
            startAmount = shakeAmount;//Set default (start) values
            startDuration = shakeDuration;//Set default (start) values
            if (!isRunning)
                StartCoroutine(Shake());//Only call the coroutine if it isn't currently running. Otherwise, just set the variables.
        }
        /// <summary>
        /// Shakes the camera.
        /// </summary>
        /// <param name="amount">Amount.</param>
        /// <param name="duration">Duration.</param>
        public void ShakeCamera(float amount, float duration) {
            shakeAmount += amount;//Add to the current amount.
            startAmount = shakeAmount;//Reset the start amount, to determine percentage.
            if (!isRunning) {
                shakeDuration += duration;//Add to the current time.
                startDuration = shakeDuration;//Reset the start time.
                StartCoroutine(Shake());//Only call the coroutine if it isn't currently running. Otherwise, just set the variables.
            }

        }
        /// <summary>
        /// Shake this instance.
        /// </summary>
        IEnumerator Shake() {
            isRunning = true;
            while (shakeDuration > 0.01f) {
                Vector3 rotationAmount = Random.insideUnitSphere * shakeAmount;//A Vector3 to add to the Local Rotation
                rotationAmount.z = 0;//Don't change the Z; it looks funny.
                shakePercentage = shakeDuration / startDuration;//Used to set the amount of shake (% * startAmount).
                shakeAmount = startAmount * shakePercentage;//Set the amount of shake (% * startAmount).
                shakeDuration = Mathf.Lerp(shakeDuration, 0, Time.deltaTime);//Lerp the time, so it is less and tapers off towards the end.
                if (smooth)
                    transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotationAmount), Time.deltaTime * smoothAmount);
                else
                    transform.localRotation = Quaternion.Euler(rotationAmount);//Set the local rotation the be the rotation amount.
                yield return null;
            }
            transform.localRotation = Quaternion.identity;//Set the local rotation to 0 when done, just to get rid of any fudging stuff.
            isRunning = false;
        }

    }
}