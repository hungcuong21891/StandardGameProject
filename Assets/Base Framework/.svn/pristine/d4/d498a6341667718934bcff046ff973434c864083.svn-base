using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace BaseFramework {
    /// <summary>
    /// User interface campaign manager.
    /// </summary>
    public class UICampaignManager : MonoBehaviour {
		/// <summary>
		/// The number item each page.
		/// </summary>
        public int numberItemEachPage;
        /// <summary>
        /// The initial position.
        /// </summary>
        public Vector2 initialPos = new Vector2(0, 0);
        /// <summary>
        /// The campaign button prefab.
        /// </summary>
        public GameObject campaignButton_Prefab;
        /// <summary>
        /// The unavailable campaign.
        /// </summary>
        public Sprite unavailableCampaign;
        /// <summary>
        /// The highest campaign.
        /// </summary>
        public Sprite highestCampaign;
        /// <summary>
        /// The canvas.
        /// </summary>
        private GameObject canvas;
        /// <summary>
        /// The content scroll view.
        /// </summary>
        private GameObject contentScrollView;
        /// <summary>
        /// The next page button.
        /// </summary>
        private GameObject nextPageButton;
        /// <summary>
        /// The previous page button.
        /// </summary>
        private GameObject prevPageButton;
        /// <summary>
        /// The close campaign button.
        /// </summary>
        private GameObject closeCampaignButton;
        /// <summary>
        /// The page.
        /// </summary>
        private int page = 1;
        /// <summary>
        /// The max page.
        /// </summary>
        private int maxPage = 0;
        /// <summary>
        /// The minimum page.
        /// </summary>
        private int minPage = 0;
        /// <summary>
        /// The best campaign.
        /// </summary>
        private int bestCampaign;
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
            bestCampaign = PlayerManager.GetInstance().bestCampaign;
            //set max/min page
            maxPage = GameManager.GetInstance().gameInformation.numberCampaign / numberItemEachPage;
            if (GameManager.GetInstance().gameInformation.numberCampaign % numberItemEachPage != 0) {
                maxPage = maxPage + 1;
            }
            minPage = 1;
            if (maxPage == 1) {
                nextPageButton.SetActive(false);
                prevPageButton.SetActive(false);
            }
            //create
            for (int i = 0; i < GameManager.GetInstance().gameInformation.numberCampaign; i++) {
                int page = i / numberItemEachPage;
                int temp = i % numberItemEachPage;
                int row = temp / 5;
                int column = temp % 5;
                //create a new campaign button
                GameObject button = GameObject.Instantiate(campaignButton_Prefab);
                button.transform.position = new Vector3(page * 1080 + initialPos.x + column * 171.5f, initialPos.y - row * 171.5f, 0);
                button.transform.SetParent(contentScrollView.transform, false);
                button.GetComponent<CampaignButton>().id = i + 1;
                button.GetComponentInChildren<Text>().text = (i + 1).ToString();
                //examine whether it is available
                if (!GameManager.GetInstance().gameInformation.unlockAllCampaigns) {
                    if (i + 1 == bestCampaign + 1) { // the best campaign which the player can play
                        button.GetComponent<Image>().sprite = highestCampaign;
                    } else if (i + 1 > bestCampaign) {
                        button.GetComponent<Image>().sprite = unavailableCampaign;
                    }
                }
            }
            //register next/prev page button
            nextPageButton.GetComponent<Button>().onClick.AddListener(delegate {
                NextPage();
            });
            prevPageButton.GetComponent<Button>().onClick.AddListener(delegate {
                PreviousPage();
            });
            closeCampaignButton.GetComponent<Button>().onClick.AddListener(delegate {
                CloseCampaign();
            });
        }
        /// <summary>
        /// Nexts the page.
        /// </summary>
        public void NextPage() {
            SoundManager.GetInstance().PlayClickSound();
            if (page < maxPage) {
                page += 1;
                Vector3 newPos = contentScrollView.transform.localPosition - new Vector3(1080, 0, 0);
                StartCoroutine(contentScrollView.GetComponent<AnimationUtil>().MovePosition(contentScrollView.transform.localPosition, newPos, true));
            }
        }
        /// <summary>
        /// Previouses the page.
        /// </summary>
        public void PreviousPage() {
            SoundManager.GetInstance().PlayClickSound();
            if (page > minPage) {
                page -= 1;
                Vector3 newPos = contentScrollView.transform.localPosition + new Vector3(1080, 0, 0);
                StartCoroutine(contentScrollView.GetComponent<AnimationUtil>().MovePosition(contentScrollView.transform.localPosition, newPos, true));
            }
        }
        /// <summary>
        /// Closes the campaign.
        /// </summary>
        public void CloseCampaign() {
            EventManager.TriggerEvent("Menu", null);
        }
		/// <summary>
		/// Autos the type of the find elements by.
		/// </summary>
        void AutoFindElementsByType() {
            canvas = GameObject.FindObjectOfType<UI_MainCanvas>().gameObject;
            contentScrollView = GetElement(typeof(ChooseCampaign_ContentScrollView));
            nextPageButton = GetElement(typeof(ChooseCampaign_NextPageButton));
            prevPageButton = GetElement(typeof(ChooseCampaign_PrevPageButton));
            closeCampaignButton = GetElement(typeof(ChooseCampaign_CloseCampaignButton));
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
    }
}