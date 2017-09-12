using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace BaseFramework {
    /// <summary>
    /// User interface shop manager.
    /// </summary>
    public class UIShopManager : MonoBehaviour {
        /// <summary>
        /// The distance between select buttons.
        /// </summary>
        public int distanceBetweenSelectButtons;
        /// <summary>
        /// The character prefab.
        /// </summary>
        public GameObject characterPrefab;
        /// <summary>
        /// The select button prefab.
        /// </summary>
        public GameObject selectButtonPrefab;
        /// <summary>
        /// The scale of character
        /// </summary>
        public Vector2 characterScale = new Vector2(1, 1);
        /// <summary>
        /// The canvas.
        /// </summary>
        private GameObject canvas;
        /// <summary>
        /// The index of the current character.
        /// </summary>
        private int currentCharacterIndex = 0;
        /// <summary>
        /// The content view character.
        /// </summary>
        private GameObject contentViewCharacter;
        /// <summary>
        /// The select view.
        /// </summary>
        private GameObject selectView;
        /// <summary>
        /// The select button.
        /// </summary>
        private GameObject selectButton;
        /// <summary>
        /// The unlock button.
        /// </summary>
        private GameObject unlockButton;
        /// <summary>
        /// The name char.
        /// </summary>
        private GameObject nameChar;
        /// <summary>
        /// The select buttons.
        /// </summary>
        private List<GameObject> selectButtons;
        /// <summary>
        /// The characters.
        /// </summary>
        private List<GameObject> characters;
        /// <summary>
        /// The close shop.
        /// </summary>
        private GameObject closeShop;
        /// <summary>
        /// The coin shop.
        /// </summary>
        private GameObject coinShop;
        /// <summary>
        /// The next char button.
        /// </summary>
        private GameObject nextCharButton;
        /// <summary>
        /// The previous char button.
        /// </summary>
        private GameObject prevCharButton;
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
            //create character
            characters = new List<GameObject>();
            selectButtons = new List<GameObject>();
            CreateCharacterInShop();
            CreateSelectButtons();
            //register listening events
            EventManager.StartListening("SwipeTurnLeft", NextChar);
            EventManager.StartListening("SwipeTurnRight", PrevChar);
            EventManager.StartListening("UnlockSuccessful", UnlockSuccessful);
            //register listening buttons
            nextCharButton.GetComponent<Button>().onClick.AddListener(delegate {
                NextChar(null);
            });
            prevCharButton.GetComponent<Button>().onClick.AddListener(delegate {
                PrevChar(null);
            });
            closeShop.GetComponent<Button>().onClick.AddListener(delegate {
                OnTouchCloseShop();
            });
            coinShop.GetComponent<Button>().onClick.AddListener(delegate {
                OnTouchCoinShop();
            });
            selectButton.GetComponent<Button>().onClick.AddListener(delegate {
                OnSelectCharacter();
            });
            unlockButton.GetComponent<Button>().onClick.AddListener(delegate {
                OnUnlockCharacter();
            });
            //update player coin
            coinShop.GetComponentInChildren<Text>().text = PlayerManager.GetInstance().playerCoin.ToString();
        }
        /// <summary>
        /// Creates the character in shop.
        /// </summary>
        void CreateCharacterInShop() {
            for (int i = 0; i < CharacterManager.GetInstance().listOfCharacters.characters.Count; i++) {
                Character currentCharacter = CharacterManager.GetInstance().listOfCharacters.characters[i];
                //create
                GameObject newCharacter = GameObject.Instantiate(characterPrefab);
                newCharacter.transform.position = newCharacter.transform.position + new Vector3(238 * i, 0, 0);
                newCharacter.transform.SetParent(contentViewCharacter.transform, false);
                //save info to gameObject
                newCharacter.GetComponent<CharacterInfo>().id = currentCharacter.id;
                newCharacter.GetComponent<CharacterInfo>().name = currentCharacter.name;
                newCharacter.GetComponent<CharacterInfo>().cost = currentCharacter.cost;
                //customize image 
                Image image = newCharacter.GetComponent<Image>();
                image.sprite = currentCharacter.sprite;
                Color c = image.color;
                c.a = 0.5f;
                image.color = c;
                //check if character is unlock 
                if (PlayerManager.GetInstance().IsUnlockCharacter(currentCharacter.id)) {
                    GameObject child = newCharacter.transform.GetChild(0).gameObject;
                    child.SetActive(false);
                }
                //set native size
                newCharacter.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(newCharacter.GetComponent<Image>().overrideSprite.rect.width * characterScale.x, newCharacter.GetComponent<Image>().overrideSprite.rect.height * characterScale.y);

                //add to list
                characters.Add(newCharacter);
            }
            characters[0].transform.localScale = new Vector3(1, 1, 1);
            //check selected character
            int selectedIndex = GetIndexById(PlayerManager.GetInstance().selectCharacter);
            ResetSelectedCharacter(selectedIndex);
            //check unlock states
            CheckIfCurrentCharacterUnlock();
            //check select button
            CheckIfCurrentCharacterSelected();
            //update name
            UpdateCurrentName();
        }
        /// <summary>
        /// Creates the select buttons.
        /// </summary>
        void CreateSelectButtons() {
            int count = CharacterManager.GetInstance().listOfCharacters.characters.Count;
            for (int i = 0; i < count; i++) {
                GameObject selectButton = GameObject.Instantiate(selectButtonPrefab);
                selectButton.transform.position = selectButton.transform.position + new Vector3(distanceBetweenSelectButtons * (i - (float)(count - 1) / 2), 0, 0);// i = 0 , count = 3, 
                selectButton.GetComponent<RectTransform>().sizeDelta = new Vector2(30, 30);
                selectButton.transform.SetParent(selectView.transform, false);
                selectButtons.Add(selectButton);
            }
            selectButtons[0].GetComponent<Toggle>().isOn = true;

        }
        /// <summary>
        /// Gets the index of the character with.
        /// </summary>
        /// <returns>The character with index.</returns>
        /// <param name="index">Index.</param>
        GameObject GetCharacterWithIndex(int index) {
            for (int i = 0; i < characters.Count; i++) {
                GameObject currentCharacter = characters[i];
                if (i == index) {
                    return currentCharacter;
                }
            }
            return null;
        }
        /// <summary>
        /// Raises the touch close shop event.
        /// </summary>
        void OnTouchCloseShop() {
            EventManager.TriggerEvent("Menu", null);
        }
        /// <summary>
        /// Raises the touch coin shop event.
        /// </summary>
        void OnTouchCoinShop() {
            EventManager.TriggerEvent("CoinShop", null);
        }
        /// <summary>
        /// Raises the unlock character event.
        /// </summary>
        void OnUnlockCharacter() {
            int currentCharacterId = characters[currentCharacterIndex].GetComponent<CharacterInfo>().id;
            int cost = characters[currentCharacterIndex].GetComponent<CharacterInfo>().cost;
            EventInfo eventInfo = new EventInfo();
            eventInfo.eventInteger.Add("characterId", currentCharacterId);
            eventInfo.eventInteger.Add("cost", cost);
            //		EventManager.TriggerEvent ("UnlockCharacter", eventInfo);
            PopupManager.GetInstance().ShowPopup("Do you really want to unlock this character?", "UnlockCharacter", eventInfo);
        }
        /// <summary>
        /// Raises the select character event.
        /// </summary>
        void OnSelectCharacter() {
            ResetSelectedCharacter(currentCharacterIndex);
            int currentCharacterId = characters[currentCharacterIndex].GetComponent<CharacterInfo>().id;
            EventInfo eventInfo = new EventInfo();
            eventInfo.eventInteger.Add("characterId", currentCharacterId);
            EventManager.TriggerEvent("SelectCharacter", eventInfo);
            //turn off select button
            CheckIfCurrentCharacterSelected();
        }
        /// <summary>
        /// Nexts the char.
        /// </summary>
        /// <param name="eventInfo">Event info.</param>
        void NextChar(EventInfo eventInfo) {
            if (currentCharacterIndex < characters.Count - 1) {
                //reset scale 
                characters[currentCharacterIndex].transform.localScale = new Vector3(0.8f, 0.8f, 1);
                selectButtons[currentCharacterIndex].GetComponent<Toggle>().isOn = false;
                //move content view
                Vector3 newPosition = contentViewCharacter.transform.localPosition - new Vector3(238, 0, 0);
                StartCoroutine(contentViewCharacter.GetComponent<AnimationUtil>().MovePosition(contentViewCharacter.transform.localPosition, newPosition, true));
                //update scale
                currentCharacterIndex += 1;
                characters[currentCharacterIndex].transform.localScale = new Vector3(1, 1, 1);
                selectButtons[currentCharacterIndex].GetComponent<Toggle>().isOn = true;
                //check unlock status
                CheckIfCurrentCharacterUnlock();
                //update name
                UpdateCurrentName();
            }
        }
        /// <summary>
        /// Previouses the char.
        /// </summary>
        /// <param name="eventInfo">Event info.</param>
        void PrevChar(EventInfo eventInfo) {
            if (currentCharacterIndex > 0) {
                //reset scale
                characters[currentCharacterIndex].transform.localScale = new Vector3(0.8f, 0.8f, 1);
                selectButtons[currentCharacterIndex].GetComponent<Toggle>().isOn = false;
                //move content view
                Vector3 newPosition = contentViewCharacter.transform.localPosition + new Vector3(238, 0, 0);
                StartCoroutine(contentViewCharacter.GetComponent<AnimationUtil>().MovePosition(contentViewCharacter.transform.localPosition, newPosition, true));
                //update new scale
                currentCharacterIndex -= 1;
                characters[currentCharacterIndex].transform.localScale = new Vector3(1, 1, 1);
                selectButtons[currentCharacterIndex].GetComponent<Toggle>().isOn = true;
                //check unlock status
                CheckIfCurrentCharacterUnlock();
                //update name
                UpdateCurrentName();
            }
        }
        /// <summary>
        /// Resets the selected character.
        /// </summary>
        /// <param name="index">Index.</param>
        void ResetSelectedCharacter(int index) {
            for (int i = 0; i < characters.Count; i++) {
                GameObject currentCharacter = characters[i];
                if (i == index) {
                    Image image = currentCharacter.GetComponent<Image>();
                    Color c = image.color;
                    c.a = 1.0f;
                    image.color = c;

                } else {
                    Image image = currentCharacter.GetComponent<Image>();
                    Color c = image.color;
                    c.a = 0.5f;
                    image.color = c;
                }
            }
        }
        /// <summary>
        /// Checks if current character selected.
        /// </summary>
        void CheckIfCurrentCharacterSelected() {
            Character currentCharacter = CharacterManager.GetInstance().listOfCharacters.characters[currentCharacterIndex];
            if (currentCharacter.id == PlayerManager.GetInstance().selectCharacter) {
                selectButton.SetActive(false);
            } else {
                selectButton.SetActive(true);
            }
        }
        /// <summary>
        /// Checks if current character unlock.
        /// </summary>
        void CheckIfCurrentCharacterUnlock() {
            Character currentCharacter = CharacterManager.GetInstance().listOfCharacters.characters[currentCharacterIndex];
            if (PlayerManager.GetInstance().IsUnlockCharacter(currentCharacter.id)) {
                TurnOffUnlock();
                CheckIfCurrentCharacterSelected();
            } else {
                TurnOnUnlock(currentCharacter.cost);
            }
        }
        /// <summary>
        /// Unlocks the successful.
        /// </summary>
        /// <param name="eventInfo">Event info.</param>
        void UnlockSuccessful(EventInfo eventInfo) {
            CheckIfCurrentCharacterUnlock();
            //remove lock
            GameObject currentCharacter = characters[currentCharacterIndex];
            GameObject child = currentCharacter.transform.GetChild(0).gameObject;
            child.SetActive(false);
            currentCharacter.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            //update coin
            UpdateCoin();
        }
        /// <summary>
        /// Turns the off unlock.
        /// </summary>
        void TurnOffUnlock() {
            //the character has been unlocked
            unlockButton.SetActive(false);
            selectButton.SetActive(true);
        }
        /// <summary>
        /// Turns the on unlock.
        /// </summary>
        /// <param name="cost">Cost.</param>
        void TurnOnUnlock(int cost) {
            unlockButton.SetActive(true);
            unlockButton.GetComponentInChildren<Text>().text = cost.ToString();
            selectButton.SetActive(false);
        }
        /// <summary>
        /// Updates the coin.
        /// </summary>
        void UpdateCoin() {
            coinShop.GetComponentInChildren<Text>().text = PlayerManager.GetInstance().playerCoin.ToString();
        }
        /// <summary>
        /// Gets the index by identifier.
        /// </summary>
        /// <returns>The index by identifier.</returns>
        /// <param name="id">Identifier.</param>
        int GetIndexById(int id) {
            for (int i = 0; i < characters.Count; i++) {
                var currentChar = characters[i];
                int currentId = currentChar.GetComponent<CharacterInfo>().id;
                if (currentId == id) {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Updates the name of the current.
        /// </summary>
        void UpdateCurrentName() {
            GameObject currentCharacter = characters[currentCharacterIndex];
            string name = currentCharacter.GetComponent<CharacterInfo>().name;
            nameChar.GetComponent<Text>().text = name;
        }
		/// <summary>
		/// Autos the type of the find elements by.
		/// </summary>
        void AutoFindElementsByType() {
            canvas = GameObject.FindObjectOfType<UI_MainCanvas>().gameObject;
            closeShop = GetElement(typeof(Shop_CloseShop));
            coinShop = GetElement(typeof(Shop_CoinShop));
            nextCharButton = GetElement(typeof(Shop_NextCharButton));
            prevCharButton = GetElement(typeof(Shop_PrevCharButton));
            contentViewCharacter = GetElement(typeof(Shop_ContentViewCharacter));
            selectView = GetElement(typeof(Shop_SelectView));
            selectButton = GetElement(typeof(Shop_SelectButton));
            unlockButton = GetElement(typeof(Shop_UnlockButton));
            nameChar = GetElement(typeof(Shop_NameChar));
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