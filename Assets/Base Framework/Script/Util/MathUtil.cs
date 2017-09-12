using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BaseFramework {
    /// <summary>
    /// Math util.
    /// </summary>
    public class MathUtil {
        /// <summary>
        /// Gets the random enum.
        /// </summary>
        /// <returns>The random enum.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T GetRandomEnum<T>() {
            System.Array A = System.Enum.GetValues(typeof(T));
            T V = (T)A.GetValue(UnityEngine.Random.Range(0, A.Length));
            return V;
        }
        /// <summary>
        /// Randoms the order element.
        /// </summary>
        /// <returns>The order element.</returns>
        /// <param name="numElement">Number element.</param>
        public static List<int> RandomOrderElement(int numElement) {
            List<int> indexList = new List<int>();
            for (int i = 0; i < numElement; i++) {
                indexList.Add(i);
            }
            for (int i = numElement - 1; i > 0; i--) {
                int temp = indexList[i];
                int r = Random.Range(0, i + 1);
                indexList[i] = indexList[r];
                indexList[r] = temp;
            }
            return indexList;
        }
        /// <summary>
        /// Angles the between2 vectors.
        /// </summary>
        /// <returns>The between2 vectors.</returns>
        /// <param name="vec1">Vec1.</param>
        /// <param name="vec2">Vec2.</param>
        public static float AngleBetween2Vectors(Vector3 vec1, Vector3 vec2) {
            float dot = Vector3.Dot(vec1, vec2);
            dot = dot / (vec1.magnitude * vec2.magnitude);
            var acos = Mathf.Acos(dot);
            var angle = acos * 180 / Mathf.PI;
            return angle;
        }
        /// <summary>
        /// Gets the small angle.
        /// </summary>
        /// <returns>The small angle.</returns>
        /// <param name="angle">Angle.</param>
        public static float GetSmallAngle(float angle) {
            angle = angle % 360;
            if (angle > 180) {
                return (360 - angle);
            } else {
                return angle;
            }
        }
        /// <summary>
        /// Clamps the angle.
        /// </summary>
        /// <returns>The angle.</returns>
        /// <param name="angle">Angle.</param>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Max.</param>
        public static float ClampAngle(float angle, float min, float max) {
            angle = Mathf.Repeat(angle, 360);
            min = Mathf.Repeat(min, 360);
            max = Mathf.Repeat(max, 360);
            bool inverse = false;
            var tmin = min;
            var tangle = angle;
            if (min > 180) {
                inverse = !inverse;
                tmin -= 180;
            }
            if (angle > 180) {
                inverse = !inverse;
                tangle -= 180;
            }
            var result = !inverse ? tangle > tmin : tangle < tmin;
            if (!result)
                angle = min;

            inverse = false;
            tangle = angle;
            var tmax = max;
            if (angle > 180) {
                inverse = !inverse;
                tangle -= 180;
            }
            if (max > 180) {
                inverse = !inverse;
                tmax -= 180;
            }

            result = !inverse ? tangle < tmax : tangle > tmax;
            if (!result)
                angle = max;
            return angle;
        }
        /// <summary>
        /// Gets the vector from another vector and angle.
        /// </summary>
        /// <returns>The vector from another vector and angle.</returns>
        /// <param name="baseVector">Base vector.</param>
        /// <param name="angle">Angle.</param>
        public static Vector2 GetVectorFromAnotherVectorAndAngle(Vector2 baseVector, float angle) { //angle > 0 : clockwise, angle < 0 : anti-clockwise
            float radianAngle = Mathf.Deg2Rad * angle;
            return new Vector2(baseVector.x * Mathf.Cos(radianAngle) + baseVector.y * Mathf.Sin(radianAngle), -baseVector.x * Mathf.Sin(radianAngle) + baseVector.y * Mathf.Cos(radianAngle));
        }
        /// <summary>
        /// Reads the long number.
        /// </summary>
        /// <returns>The long number.</returns>
        /// <param name="number">Number.</param>
        public static string ReadLongNumber(float number) {
            float billions;
            float millions;
            float thousands;
            billions = number / 1000000000;
            millions = number / 1000000;
            thousands = number / 1000;
            if (billions >= 1) {
                return billions.ToString("0.0") + "B";
            } else if (millions >= 1) {
                return millions.ToString("F1") + "M";
            } else if (thousands >= 1) {
                return thousands.ToString("F1") + "K";
            } else {
                return number.ToString();
            }
        }
        /// <summary>
        /// Calculates the angle between two vectors.
        /// </summary>
        /// <returns>The angle between two vectors.</returns>
        /// <param name="vec1">Vec1.</param>
        /// <param name="vec2">Vec2.</param>
        public static float CalculateAngleBetweenTwoVectors(Vector3 vec1, Vector3 vec2) {
            float angle = Mathf.DeltaAngle(Mathf.Atan2(vec1.y, vec1.x) * Mathf.Rad2Deg,
                Mathf.Atan2(vec2.y, vec2.x) * Mathf.Rad2Deg);
            return angle;
        }


    }
}