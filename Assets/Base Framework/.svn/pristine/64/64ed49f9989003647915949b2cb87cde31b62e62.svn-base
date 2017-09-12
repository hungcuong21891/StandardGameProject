using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace BaseFramework {
	/// <summary>
	/// Popup manager.
	/// </summary>
    public class PopupManager : Singleton<PopupManager> {
        /// <summary>
        /// The command.
        /// </summary>
        private string command;
        /// <summary>
        /// The popup text.
        /// </summary>
        public GameObject popupText;
        /// <summary>
        /// The yes button.
        /// </summary>
        public GameObject yesButton;
        /// <summary>
        /// The no button.
        /// </summary>
        public GameObject noButton;
        /// <summary>
        /// The attach event info.
        /// </summary>
        private EventInfo attachEventInfo;
        /// <summary>
        /// Initialize this instance.
        /// </summary>
        protected override void Initialize() {
            this.gameObject.SetActive(false);
            yesButton.GetComponent<Button>().onClick.AddListener(delegate {
                OnYesButton();
            });
            noButton.GetComponent<Button>().onClick.AddListener(delegate {
                OnNoButton();
            });
        }
        /// <summary>
        /// Shows the popup.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="command">Command.</param>
        /// <param name="eventInfo">Event info.</param>
        public void ShowPopup(string text, string command, EventInfo eventInfo) {
            this.gameObject.SetActive(true);
            this.popupText.GetComponent<Text>().text = text;
            this.command = command;
            this.attachEventInfo = eventInfo;
        }
        /// <summary>
        /// Raises the yes button event.
        /// </summary>
        void OnYesButton() {
            gameObject.SetActive(false);
            EventManager.TriggerEvent(command, attachEventInfo);

        }
        /// <summary>
        /// Raises the no button event.
        /// </summary>
        void OnNoButton() {
            gameObject.SetActive(false);
        }
    }
}