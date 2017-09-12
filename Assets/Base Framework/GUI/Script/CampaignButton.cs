using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace BaseFramework {
	/// <summary>
	/// Campaign button.
	/// </summary>
    public class CampaignButton : MonoBehaviour {
        /// <summary>
        /// The identifier.
        /// </summary>
        public int id;
        /// <summary>
        /// Start this instance.
        /// </summary>
        void Start() {
            this.GetComponent<Button>().onClick.AddListener(delegate {
                OnEnterGame();
            });

        }
        /// <summary>
        /// Raises the enter game event.
        /// </summary>
        void OnEnterGame() {
            if (GameManager.GetInstance().gameInformation.unlockAllCampaigns) {
                EnterGame();
            } else {
                if (id <= PlayerManager.GetInstance().bestCampaign + 1) {
                    EnterGame();
                }
            }
        }
		/// <summary>
		/// Enters the game.
		/// </summary>
        void EnterGame() {
            SoundManager.GetInstance().PlayClickSound();
            GameManager.GetInstance().gameInformation.currentCampaign = id;
            EventManager.TriggerEvent("EnterMap", null);
        }
    }
}