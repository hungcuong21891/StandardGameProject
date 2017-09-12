using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace BaseFramework {
	/// <summary>
	/// Synchronize user interface color.
	/// </summary>
    public class SynchronizeUIColor : MonoBehaviour {
		/// <summary>
		/// The text.
		/// </summary>
        private Text text;
		/// <summary>
		/// The image.
		/// </summary>
        private Image image;
		/// <summary>
		/// Awake this instance.
		/// </summary>
        void Awake() {
            text = GetComponent<Text>();
            image = GetComponent<Image>();
        }
		/// <summary>
		/// Start this instance.
		/// </summary>
        void Start() {
            if (text != null) {
                text.color = GameManager.GetInstance().gameInformation.mainColorUI;
            }
            if (image != null) {
                image.color = GameManager.GetInstance().gameInformation.mainColorUI;
            }
        }
    }
}