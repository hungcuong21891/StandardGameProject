using UnityEngine;
using System.Collections;

namespace BaseFramework {
    /// <summary>
    /// Range random.
    /// </summary>
    public struct RangeRandom {
        /// <summary>
        /// The minimum.
        /// </summary>
        public float min;
        /// <summary>
        /// The max.
        /// </summary>
        public float max;
        /// <summary>
        /// Initializes a new instance of the <see cref="RangeRandom"/> struct.
        /// </summary>
        /// <param name="min">Minimum.</param>
        /// <param name="max">Max.</param>
        public RangeRandom(float min, float max) {
            this.min = min;
            this.max = max;
        }
    }
    /// <summary>
    /// Common util.
    /// </summary>
    public class CommonUtil : MonoBehaviour {
        /// <summary>
        /// Randoms the float multiple range.
        /// </summary>
        /// <returns>The float multiple range.</returns>
        /// <param name="range">Range.</param>
        /// <param name="exclusive">Exclusive.</param>
        public static float RandomFloatMultipleRange(RangeRandom range, RangeRandom exclusive) {
            if (exclusive.max > range.max) {
                exclusive.max = range.max;
            }
            if (exclusive.min < range.min) {
                exclusive.min = range.min;
            }
            float excluded = exclusive.max - exclusive.min;
            float newMax = range.max - excluded;
            float outcome = Random.Range(range.min, newMax);
            if (outcome > exclusive.min) {
                outcome = outcome + excluded;
            }
            return outcome;
        }
    }
}