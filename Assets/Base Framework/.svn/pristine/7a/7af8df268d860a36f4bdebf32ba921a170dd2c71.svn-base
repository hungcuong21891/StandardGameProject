using UnityEngine;
using System.Collections;

namespace BaseFramework {
    /// <summary>
    /// Game center IO.
    /// </summary>
    public class GameCenterIOS : Singleton<GameCenterIOS> {
        /// <summary>
        /// The leaderboard ID.
        /// </summary>
        public string leaderboardID;
        /// <summary>
        /// The is authenticated.
        /// </summary>
        private static bool isAuthenticated = false;
        /// <summary>
        /// Initialize this instance.
        /// </summary>
        protected override void Initialize() {

        }
        /// <summary>
        /// Start this instance.
        /// </summary>
        void Start() {
            AuthenticateToGameCenter();
        }
        /// <summary>
        /// Authenticates to game center.
        /// </summary>
        public static void AuthenticateToGameCenter() {
#if UNITY_IPHONE
			Social.localUser.Authenticate(success => {
				if (success) {
					isAuthenticated = true;
					Debug.Log("Authentication successful");
				}
				else {
					isAuthenticated = false;
					Debug.Log("Authentication failed");
				}
			});
#endif
        }
        /// <summary>
        /// Reports the score.
        /// </summary>
        /// <param name="score">Score.</param>
        /// <param name="leaderboardID">Leaderboard I.</param>
        public static void ReportScore(long score, string leaderboardID) {
#if UNITY_IPHONE
		if (isAuthenticated) {
			//Debug.Log("Reporting score " + score + " on leaderboard " + leaderboardID);
			Social.ReportScore(score, leaderboardID, success => {
				if (success) {
					Debug.Log("Reported score successfully");
				}
				else {
					Debug.Log("Failed to report score");
				}
			});
		}
#endif
        }
        /// <summary>
        /// Reports the achivement.
        /// </summary>
        /// <param name="achievementID">Achievement I.</param>
        public static void ReportAchivement(string achievementID) {
#if UNITY_IPHONE
		if (isAuthenticated) {
			Social.ReportProgress(achievementID, 100.0f, success => {
				if (success) {
					Debug.Log("Reported score successfully");
				}
				else {
					Debug.Log("Failed to report score");
				}
			});
		}
#endif
        }
        /// <summary>
        /// Shows the leaderboard.
        /// </summary>
        public static void ShowLeaderboard() {
#if UNITY_IPHONE
			Social.ShowLeaderboardUI();
#endif
        }
        /// <summary>
        /// Shows the achievement.
        /// </summary>
        public static void ShowAchievement() {
#if UNITY_IPHONE
		Social.ShowAchievementsUI();
#endif
        }
    }
}