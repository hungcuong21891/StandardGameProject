using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace BaseFramework {
    /// <summary>
    /// User interface menu manager.
    /// </summary>
    public class UIMenuManager : MonoBehaviour {
		/// <summary>
		/// The canvas.
		/// </summary>
        private GameObject canvas;
        /// <summary>
        /// The play button.
        /// </summary>
        private Object[] playButton;
        /// <summary>
        /// The option button.
        /// </summary>
        private GameObject optionButton;
        /// <summary>
        /// The game center.
        /// </summary>
        private GameObject gameCenter;
        /// <summary>
        /// The leaderboard.
        /// </summary>
        private GameObject leaderboard;
        /// <summary>
        /// The achievement.
        /// </summary>
        private GameObject achievement;
        /// <summary>
        /// The shop.
        /// </summary>
        private GameObject shop;
        /// <summary>
        /// The remove ads.
        /// </summary>
        private GameObject removeAds;
        /// <summary>
        /// The restore IA.
        /// </summary>
        private GameObject restoreIAP;
        /// <summary>
        /// The kid mode.
        /// </summary>
        private GameObject kidMode;
        /// <summary>
        /// The sound.
        /// </summary>
        private GameObject sound;
        /// <summary>
        /// The credits.
        /// </summary>
        private GameObject credits;
        /// <summary>
        /// The content view option.
        /// </summary>
        private GameObject contentViewOption;
        /// <summary>
        /// The is open option.
        /// </summary>
        private bool isOpenOption = false;
        /// <summary>
        /// Awake this instance.
        /// </summary>
        void Awake() {
            AutoFindElementsByType();
        }
        /// <summary>
        /// Start this instance.
        /// </summary>
        void Start() {
            if (PlayerManager.GetInstance().kidModeOn == 0) {
                kidMode.GetComponent<Toggle>().isOn = false;
            } else {
                kidMode.GetComponent<Toggle>().isOn = true;
            }
            if (PlayerManager.GetInstance().soundOn == 0) {
                sound.GetComponent<Toggle>().isOn = false;
            } else {
                sound.GetComponent<Toggle>().isOn = true;
            }
            foreach (GameObject Index in playButton) {
                Index.GetComponent<Button>().onClick.AddListener(delegate {
                    OnTouchPlayButton(Index);
                });
            }
            //playButton.GetComponent<Button>().onClick.AddListener(delegate {
            //    OnTouchPlayButton();
            //});
            optionButton.GetComponent<Button>().onClick.AddListener(delegate {
                OnTouchOptionButton();
            });
            //gameCenter.GetComponent<Button>().onClick.AddListener(delegate {
            //    OnTouchGameCenter();
            //});
            leaderboard.GetComponent<Button>().onClick.AddListener(delegate {
                OnTouchLeaderboard();
            });
            achievement.GetComponent<Button>().onClick.AddListener(delegate {
                OnTouchAchievement();
            });
            shop.GetComponent<Button>().onClick.AddListener(delegate {
                OnTouchShop();
            });
            removeAds.GetComponent<Button>().onClick.AddListener(delegate {
                OnTouchRemoveAds();
            });
            restoreIAP.GetComponent<Button>().onClick.AddListener(delegate {
                OnTouchRestoreIAP();
            });
            kidMode.GetComponent<Toggle>().onValueChanged.AddListener(delegate {
                OnTouchKidMode();
            });
            credits.GetComponent<Button>().onClick.AddListener(delegate {
                OnTouchCredits();
            });
            sound.GetComponent<Toggle>().onValueChanged.AddListener(delegate {
                OnTouchSound();
            });
            //disable shop button when don't use shop feature
            if (!GameManager.GetInstance().gameInformation.hasShopScene) {
                if (shop != null) {
                    shop.SetActive(false);
                }
            } else {
                if (shop != null) {
                    shop.SetActive(true);
                }
            }
        }
        /// <summary>
        /// Raises the touch play button event.
        /// </summary>
        void OnTouchPlayButton(GameObject Caller) {
            Menu_PlayButton MPB = Caller.GetComponent<Menu_PlayButton>();
            string Name = "";
            if (MPB != null) {
                Name = MPB.LoadingScene;
            }
            EventInfo eventInfo = new EventInfo();
            eventInfo.eventString.Add("Name", Name);
            EventManager.TriggerEvent("PlayGame", eventInfo);
        }
        /// <summary>
        /// Raises the touch option button event.
        /// </summary>
        void OnTouchOptionButton() {
            //on/off option column
            isOpenOption = !isOpenOption;
            if (isOpenOption == true) {
                contentViewOption.GetComponent<Animator>().SetBool("optionOn", true);
            } else {
                contentViewOption.GetComponent<Animator>().SetBool("optionOn", false);
            }

        }
        /// <summary>
        /// Raises the touch game center event.
        /// </summary>
        void OnTouchGameCenter() {
            EventManager.TriggerEvent("GameCenter", null);
        }
        /// <summary>
        /// Raises the touch leaderboard event.
        /// </summary>
        void OnTouchLeaderboard() {
            EventManager.TriggerEvent("Leaderboard", null);
        }
        /// <summary>
        /// Raises the touch achievement event.
        /// </summary>
        void OnTouchAchievement() {
            EventManager.TriggerEvent("Achievement", null);
        }
        /// <summary>
        /// Raises the touch shop event.
        /// </summary>
        void OnTouchShop() {
            EventManager.TriggerEvent("Shop", null);
        }
        /// <summary>
        /// Raises the touch remove ads event.
        /// </summary>
        void OnTouchRemoveAds() {
            //remove ads
            EventManager.TriggerEvent("RemoveAds", null);
        }
        /// <summary>
        /// Raises the touch restore IA event.
        /// </summary>
        void OnTouchRestoreIAP() {
            //restore in app purchase
            EventManager.TriggerEvent("RestoreIAP", null);
        }
        /// <summary>
        /// Raises the touch kid mode event.
        /// </summary>
        void OnTouchKidMode() {
            //on/off kidmode
            if (kidMode.GetComponent<Toggle>().isOn) {
                EventManager.TriggerEvent("TurnKidModeOn", null);
            } else {
                EventManager.TriggerEvent("TurnKidModeOff", null);
            }
        }
        /// <summary>
        /// Raises the touch sound event.
        /// </summary>
        void OnTouchSound() {
            //on/off sound
            if (sound.GetComponent<Toggle>().isOn) {
                //bat sound
                EventManager.TriggerEvent("TurnSoundOn", null);
            } else {
                //tat sound
                EventManager.TriggerEvent("TurnSoundOff", null);
            }
        }
        /// <summary>
        /// Raises the touch credits event.
        /// </summary>
        void OnTouchCredits() {
            //show credits
            EventManager.TriggerEvent("Credits", null);
        }
		/// <summary>
		/// Autos the type of the find elements by.
		/// </summary>
        void AutoFindElementsByType() {
            canvas = GameObject.FindObjectOfType<UI_MainCanvas>().gameObject;
            //playButton = GetElements(typeof(Menu_PlayButton));
            Menu_PlayButton[] MPB = GameObject.FindObjectsOfType<Menu_PlayButton>() as Menu_PlayButton[];
            playButton = new GameObject[MPB.Length];
            for (int Z = 0; Z < MPB.Length; Z++) {
                playButton[Z] = MPB[Z].gameObject;
            }
            optionButton = GetElement(typeof(Menu_OptionButton));
            leaderboard = GetElement(typeof(Menu_Leaderboard));
            achievement = GetElement(typeof(Menu_Achievement));
            shop = GetElement(typeof(Menu_Shop));
            removeAds = GetElement(typeof(Menu_RemoveAds));
            restoreIAP = GetElement(typeof(Menu_RestoreIAP));
            kidMode = GetElement(typeof(Menu_KidMode));
            sound = GetElement(typeof(Menu_Sounds));
            credits = GetElement(typeof(Menu_Credits));
            contentViewOption = GetElement(typeof(Menu_ContentViewOption));
        }
		/// <summary>
		/// Gets the element.
		/// </summary>
		/// <returns>The element.</returns>
		/// <param name="type">Type.</param>
        GameObject GetElement(System.Type type) {
            if (canvas.transform.GetComponentInChildren(type, true) != null) {
                return canvas.transform.GetComponentInChildren(type, true).gameObject;
            } else {
                return null;
            }
        }
        //GameObject[] GetElements(System.Type type) {
        //    GameObject[] Idx = GameObject.FindObjectsOfType(type);
        //    GameObject[] Return = new GameObject[Idx.Length];
        //    for (int Z = 0; Z < Idx.Length; Z++) {
        //        Return[Z] = Idx[Z].
        //    }
        //    return Return;
        //    return Idx;
        //}
    }
}