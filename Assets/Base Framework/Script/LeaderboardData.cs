using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BaseFramework {
    /// <summary>
    /// Leaderboard platform.
    /// </summary>
    public enum LeaderboardPlatform {
        ANDROID,
        IOS
    }
    /// <summary>
    /// Leaderboard.
    /// </summary>
    [System.Serializable]
    public class Leaderboard {
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
        public LeaderboardPlatform platform;
    }
    /// <summary>
    /// Leaderboard data.
    /// </summary>
    [CreateAssetMenu(fileName = "LeaderboardData", menuName = "Leaderboard", order = 1)]
    public class LeaderboardData : ScriptableObject {
        /// <summary>
        /// The list leaderboard.
        /// </summary>
        public List<Leaderboard> listLeaderboard;
        /// <summary>
        /// Gets the name of the leaderboard identifier by.
        /// </summary>
        /// <returns>The leaderboard identifier by name.</returns>
        /// <param name="name">Name.</param>
        public string GetLeaderboardIDByName(string name) {
            foreach (Leaderboard element in listLeaderboard) {
                if (name.Equals(element.name)) {
                    return element.id;
                }
            }
            return null;
        }
		public string GetLeaderboardIDByName(string name, LeaderboardPlatform platform) {
			foreach (Leaderboard element in listLeaderboard) {
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