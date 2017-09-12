using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace BaseFramework {
    /// <summary>
    /// User interface button.
    /// </summary>
    public class UIButton : MonoBehaviour {
        /// <summary>
        /// The button sound.
        /// </summary>
        public AudioClip buttonSound;
        /// <summary>
        /// Start this instance.
        /// </summary>
        void Start() {
            this.GetComponent<Button>().onClick.AddListener(delegate {
                OnClickButton();
            });
        }
        /// <summary>
        /// Raises the click button event.
        /// </summary>
        void OnClickButton() {
            if (buttonSound == null) {
                SoundManager.GetInstance().PlaySfx(SoundManager.GetInstance().clickSound);
            } else {
                SoundManager.GetInstance().PlaySfx(buttonSound);
            }
        }
    }
}