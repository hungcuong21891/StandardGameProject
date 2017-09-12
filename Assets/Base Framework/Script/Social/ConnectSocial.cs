using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
using System.Collections.Generic;
#if UNITY_ANDROID
using GooglePlayGames;
using GooglePlayGames.BasicApi;
#endif
namespace BaseFramework {
    /// <summary>
    /// Connect social.
    /// </summary>
    public class ConnectSocial : Singleton<ConnectSocial> {
        /// <summary>
        /// The leaderboard data.
        /// </summary>
        public LeaderboardData leaderboardData;
        /// <summary>
        /// The achievement data.
        /// </summary>
        public AchievementData achievementData;
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
            ActivateGooglePlayService();
            AuthenticateToSocial();
        }
        /// <summary>
        /// Activates the google play service.
        /// </summary>
        public static void ActivateGooglePlayService() {
#if UNITY_ANDROID
            PlayGamesPlatform.Activate();
#endif
        }
        /// <summary>
        /// Authenticates to social.
        /// </summary>
        public static void AuthenticateToSocial() {
#if UNITY_IPHONE || UNITY_ANDROID
            Social.localUser.Authenticate(success => {
                if (success) {
                    isAuthenticated = true;
                    Debug.Log("Authentication successful");
                } else {
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
#if UNITY_IPHONE || UNITY_ANDROID
            if (isAuthenticated) {
                //Debug.Log("Reporting score " + score + " on leaderboard " + leaderboardID);
                Social.ReportScore(score, leaderboardID, success => {
                    if (success) {
                        Debug.Log("Reported score successfully");
                    } else {
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
#if UNITY_IPHONE || UNITY_ANDROID
            if (isAuthenticated) {
                Social.ReportProgress(achievementID, 100.0f, success => {
                    if (success) {
                        Debug.Log("Reported score successfully");
                    } else {
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
#if UNITY_IPHONE || UNITY_ANDROID
            Social.ShowLeaderboardUI();
#endif
        }
        /// <summary>
        /// Shows the achievement.
        /// </summary>
        public static void ShowAchievement() {
#if UNITY_IPHONE || UNITY_ANDROID
            Social.ShowAchievementsUI();
#endif
        }
    }
}