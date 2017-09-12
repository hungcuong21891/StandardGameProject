using UnityEngine;
using System.Collections;

namespace BaseFramework {
    /// <summary>
    /// Game manager.
    /// </summary>
    public class GameManager : Singleton<GameManager> {
        /// <summary>
        /// The game information.
        /// </summary>
        public GameInformation gameInformation;
        /// <summary>
        /// The coin pack information.
        /// </summary>
        public CoinPackInformation coinPackInformation;
		/// <summary>
		/// My game information.
		/// </summary>
		public MyGameInformation myGameInformation;
        /// <summary>
        /// The is pause game.
        /// </summary>
        [System.NonSerialized]
        public bool isPauseGame = false;
        /// <summary>
        /// Initialize this instance.
        /// </summary>
        protected override void Initialize() {
            Screen.SetResolution(1080, 1920, true);
        }
    }
}