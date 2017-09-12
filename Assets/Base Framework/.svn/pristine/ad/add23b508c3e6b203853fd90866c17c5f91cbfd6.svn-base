using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace BaseFramework {
	/// <summary>
	/// User interface toggle.
	/// </summary>
    public class UIToggle : MonoBehaviour {
        /// <summary>
        /// Start this instance.
        /// </summary>
        void Start() {
            this.GetComponent<Toggle>().onValueChanged.AddListener(delegate {
                OnToggleButton();
            });
        }
        /// <summary>
        /// Raises the toggle button event.
        /// </summary>
        void OnToggleButton() {
            SoundManager.GetInstance().PlaySfx(SoundManager.GetInstance().clickSound);
        }
    }
}