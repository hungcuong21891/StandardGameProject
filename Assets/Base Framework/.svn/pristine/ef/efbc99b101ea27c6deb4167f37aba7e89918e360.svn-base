using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BaseFramework {
    /// <summary>
    /// Achievement platform.
    /// </summary>
    public enum AchievementPlatform {
        ANDROID,
        IOS
    }
    /// <summary>
    /// Achievement.
    /// </summary>
    [System.Serializable]
    public class Achievement {
        /// <summary>
        /// The name.
        /// </summary>
        public string name;
        /// <summary>
        /// The identifier.
        /// </summary>
        public string id;
        /// <summary>
        /// The platform.
        /// </summary>
        public AchievementPlatform platform;
    }
    /// <summary>
    /// Achievement data.
    /// </summary>
    [CreateAssetMenu(fileName = "AchievementData", menuName = "Achievement", order = 1)]
    public class AchievementData : ScriptableObject {
        /// <summary>
        /// The list achievements.
        /// </summary>
        public List<Achievement> listAchievements;
        /// <summary>
        /// Gets the name of the achievement identifier by.
        /// </summary>
        /// <returns>The achievement identifier by name.</returns>
        /// <param name="name">Name.</param>
        public string GetAchievementIDByName(string name) {
            foreach (Achievement element in listAchievements) {
                if (name.Equals(element.name)) {
                    return element.id;
                }
            }
            return null;
        }

		public string GetAchievementIDByName(string name, AchievementPlatform platform) {
			foreach (Achievement element in listAchievements) {
				if (element.platform == platform) {
					if (name.Equals (element.name)) {
						return element.id;
					}
				}
			}
			return null;
		}
    }
}