using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace BaseFramework {
    /// <summary>
    /// Animation util.
    /// </summary>
    public class AnimationUtil : MonoBehaviour {
        /// <summary>
        /// The time move.
        /// </summary>
        public float timeMove = 0.1f;
        /// <summary>
        /// The time rotate.
        /// </summary>
        public float timeRotate = 0.5f;
        /// <summary>
        /// The duration of the fade.
        /// </summary>
        public float fadeDuration = 0.3f;
        /// <summary>
        /// The scale rate.
        /// </summary>
        public float scaleRate = 1.1f;
        /// <summary>
        /// The time scale.
        /// </summary>
        public float timeScale = 0.2f;
        /// <summary>
        /// The angle.
        /// </summary>
        private float tAngle = 0;
        /// <summary>
        /// The position.
        /// </summary>
        private float tPos = 0;
        /// <summary>
        /// The color.
        /// </summary>
        private float tColor = 0f;
        /// <summary>
        /// The scale.
        /// </summary>
        private float tScale = 0f;

        /// <summary>
        /// Moves the position.
        /// </summary>
        /// <returns>The position.</returns>
        /// <param name="pos1">Pos1.</param>
        /// <param name="pos2">Pos2.</param>
        /// <param name="isLocalPosition">If set to <c>true</c> is local position.</param>
        public IEnumerator MovePosition(Vector3 pos1, Vector3 pos2, bool isLocalPosition = false) {
            while (tPos < 1) {
                tPos = tPos + Time.deltaTime / timeMove;
                Vector3 newPosition = Vector3.Lerp(pos1, pos2, tPos);
                if (isLocalPosition == false) {
                    transform.position = newPosition;
                } else {
                    transform.localPosition = newPosition;
                }
                yield return false;
            }
            tPos = 0;
        }
        /// <summary>
        /// Moves the and back position.
        /// </summary>
        /// <returns>The and back position.</returns>
        /// <param name="pos1">Pos1.</param>
        /// <param name="pos2">Pos2.</param>
        /// <param name="isLocalPosition">If set to <c>true</c> is local position.</param>
        public IEnumerator MoveAndBackPosition(Vector3 pos1, Vector3 pos2, bool patrol = false, bool isLocalPosition = false) {
            yield return MovePosition(pos1, pos2, isLocalPosition);
            yield return MovePosition(pos2, pos1, isLocalPosition);
            if (patrol) {
                StartCoroutine(MoveAndBackPosition(pos1, pos2, isLocalPosition));
            }
        }
        /// <summary>
        /// Rotate the specified r1 and r2.
        /// </summary>
        /// <param name="r1">R1.</param>
        /// <param name="r2">R2.</param>
        public IEnumerator Rotate(Vector3 r1, Vector3 r2) {
            while (tAngle < 1) {
                tAngle = tAngle + Time.deltaTime / timeRotate;
                Vector3 newRotation = Vector3.Lerp(r1, r2, tAngle);
                transform.rotation = Quaternion.Euler(newRotation);
                yield return false;
            }
            tAngle = 0;
        }
        /// <summary>
        /// Fades the sprite.
        /// </summary>
        /// <returns>The sprite.</returns>
        /// <param name="colorStart">Color start.</param>
        /// <param name="colorEnd">Color end.</param>
        public IEnumerator FadeSprite(Color colorStart, Color colorEnd) {
            while (tColor < 1) {
                tColor = tColor + Time.deltaTime / fadeDuration;
                Color newColor = Color.Lerp(colorStart, colorEnd, tColor);
                GetComponent<SpriteRenderer>().color = newColor;
                yield return false;
            }
            tColor = 0;
        }
        /// <summary>
        /// Fades the text.
        /// </summary>
        /// <returns>The text.</returns>
        /// <param name="colorStart">Color start.</param>
        /// <param name="colorEnd">Color end.</param>
        public IEnumerator FadeText(Color colorStart, Color colorEnd) {
            while (tColor < 1) {
                tColor = tColor + Time.deltaTime / fadeDuration;
                Color newColor = Color.Lerp(colorStart, colorEnd, tColor);
                GetComponent<Text>().color = newColor;
                yield return false;
            }
            tColor = 0;
        }
        /// <summary>
        /// Fades the image.
        /// </summary>
        /// <returns>The image.</returns>
        /// <param name="colorStart">Color start.</param>
        /// <param name="colorEnd">Color end.</param>
        public IEnumerator FadeImage(Color colorStart, Color colorEnd) {
            while (tColor < 1) {
                tColor = tColor + Time.deltaTime / fadeDuration;
                Color newColor = Color.Lerp(colorStart, colorEnd, tColor);
                GetComponent<Image>().color = newColor;
                yield return false;
            }
            tColor = 0;
        }
        /// <summary>
        /// Scale this instance.
        /// </summary>
        public IEnumerator Scale() {
            while (tScale < 1) {
                tScale = tScale + Time.deltaTime / timeScale;
                Vector3 newScale = Vector3.Lerp(transform.localScale, transform.localScale * scaleRate, tScale);
                transform.localScale = newScale;

                yield return false;
            }
            tScale = 0;
        }
        /// <summary>
        /// Stops all my coroutines.
        /// </summary>
        public void StopAllMyCoroutines() {
            StopAllCoroutines();
        }
    }
}