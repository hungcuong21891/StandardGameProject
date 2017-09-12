using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;

namespace BaseFramework {
    /// <summary>
    /// Swipe util.
    /// </summary>
    public class SwipeUtil : MonoBehaviour {
        /// <summary>
        /// The finger start time.
        /// </summary>
        private float fingerStartTime = 0.0f;
        /// <summary>
        /// The finger start position.
        /// </summary>
        private Vector2 fingerStartPos = Vector2.zero;
        /// <summary>
        /// The is swipe.
        /// </summary>
        private bool isSwipe = false;
        /// <summary>
        /// The minimum swipe dist.
        /// </summary>
        private float minSwipeDist = 100.0f;
        /// <summary>
        /// The max swipe time.
        /// </summary>
        private float maxSwipeTime = 0.5f;
        /// <summary>
        /// Update this instance.
        /// </summary>
        void Update() {
            if (Input.touchCount > 0) {
                foreach (Touch touch in Input.touches) {
                    switch (touch.phase) {
                        case TouchPhase.Began:
                            /* this is a new touch */
                            isSwipe = true;
                            fingerStartTime = Time.time;
                            fingerStartPos = touch.position;
                            break;
                        case TouchPhase.Canceled:
                            /* The touch is being canceled */
                            isSwipe = false;
                            break;
                        case TouchPhase.Ended:
                            float gestureTime = Time.time - fingerStartTime;
                            float gestureDist = (touch.position - fingerStartPos).magnitude;
                            if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist) {
                                Vector2 direction = touch.position - fingerStartPos;
                                Vector2 swipeType = Vector2.zero;
                                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
                                    // the swipe is horizontal:
                                    swipeType = Vector2.right * Mathf.Sign(direction.x);
                                } else {
                                    // the swipe is vertical:
                                    swipeType = Vector2.up * Mathf.Sign(direction.y);
                                }
                                if (Mathf.Abs(swipeType.x) > Mathf.Abs(swipeType.y)) {
                                    if (swipeType.x != 0.0f) {
                                        if (swipeType.x > 0.0f) {
                                            // MOVE RIGHT
                                            EventManager.TriggerEvent("SwipeTurnRight", null);
                                        } else {
                                            // MOVE LEFT
                                            EventManager.TriggerEvent("SwipeTurnLeft", null);
                                        }
                                    }
                                } else {
                                    if (swipeType.y != 0.0f) {
                                        if (swipeType.y > 0.0f) {
                                            // MOVE UP
                                            EventManager.TriggerEvent("SwipeTurnUp", null);
                                        } else {
                                            // MOVE DOWN
                                            EventManager.TriggerEvent("SwipeTurnDown", null);
                                        }
                                    }
                                }
                            }
                            break;
                    }
                }
            }

        }
    }
}