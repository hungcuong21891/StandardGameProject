using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace BaseFramework {
    /// <summary>
    /// User interface coin shop manager.
    /// </summary>
    public class UICoinShopManager : MonoBehaviour {
		/// <summary>
		/// The currency unit.
		/// </summary>
        public string currencyUnit;
        /// <summary>
        /// The canvas.
        /// </summary>
        private GameObject canvas;
        /// <summary>
        /// The close coin shop.
        /// </summary>
        private GameObject closeCoinShop;
        /// <summary>
        /// The buy type1.
        /// </summary>
        private GameObject buyType1;
		/// <summary>
		/// The cost text type1.
		/// </summary>
        private GameObject costTextType1;
		/// <summary>
		/// The coin text type1.
		/// </summary>
        private GameObject coinTextType1;
        /// <summary>
        /// The buy type2.
        /// </summary>
        private GameObject buyType2;
		/// <summary>
		/// The cost text type2.
		/// </summary>
        private GameObject costTextType2;
		/// <summary>
		/// The coin text type2.
		/// </summary>
        private GameObject coinTextType2;
        /// <summary>
        /// The buy type3.
        /// </summary>
        private GameObject buyType3;
		/// <summary>
		/// The cost text type3.
		/// </summary>
        private GameObject costTextType3;
		/// <summary>
		/// The coin text type3.
		/// </summary>
        private GameObject coinTextType3;
        /// <summary>
        /// The coin.
        /// </summary>
        private GameObject coin;
		/// <summary>
		/// The coin pack info.
		/// </summary>
        private CoinPackInformation coinPackInfo;
		/// <summary>
		/// Awake this instance.
		/// </summary>
        void Awake() {
            coinPackInfo = GameManager.GetInstance().coinPackInformation;
            AutoFindElementsByType();
        }
        /// <summary>
        /// Start this instance.
        /// </summary>
        void Start() {
            //type1
            buyType1.GetComponent<Button>().onClick.AddListener(delegate {
                OnTouchBuyType1();
            });
            costTextType1.GetComponent<Text>().text = currencyUnit + coinPackInfo.coinPack1.cost.ToString();
            coinTextType1.GetComponent<Text>().text = "+" + coinPackInfo.coinPack1.addedCoin.ToString();
            buyType2.GetComponent<Button>().onClick.AddListener(delegate {
                OnTouchBuyType2();
            });
            costTextType2.GetComponent<Text>().text = currencyUnit + coinPackInfo.coinPack2.cost.ToString();
            coinTextType2.GetComponent<Text>().text = "+" + coinPackInfo.coinPack2.addedCoin.ToString();
            buyType3.GetComponent<Button>().onClick.AddListener(delegate {
                OnTouchBuyType3();
            });
            costTextType3.GetComponent<Text>().text = currencyUnit + coinPackInfo.coinPack3.cost.ToString();
            coinTextType3.GetComponent<Text>().text = "+" + coinPackInfo.coinPack3.addedCoin.ToString();
            closeCoinShop.GetComponent<Button>().onClick.AddListener(delegate {
                OnCloseCoinShop();
            });
            coin.GetComponent<Text>().text = PlayerManager.GetInstance().playerCoin.ToString();
        }
        /// <summary>
        /// Raises the touch buy type1 event.
        /// </summary>
        void OnTouchBuyType1() {
            EventManager.TriggerEvent("BuyType1", null);
        }
        /// <summary>
        /// Raises the touch buy type2 event.
        /// </summary>
        void OnTouchBuyType2() {
            EventManager.TriggerEvent("BuyType2", null);
        }
        /// <summary>
        /// Raises the touch buy type3 event.
        /// </summary>
        void OnTouchBuyType3() {
            EventManager.TriggerEvent("BuyType3", null);
        }
        /// <summary>
        /// Raises the close coin shop event.
        /// </summary>
        void OnCloseCoinShop() {
            EventManager.TriggerEvent("Shop", null);
        }
		/// <summary>
		/// Update this instance.
		/// </summary>
        void Update() {
            coin.GetComponent<Text>().text = PlayerManager.GetInstance().playerCoin.ToString();
        }
		/// <summary>
		/// Autos the type of the find elements by.
		/// </summary>
        void AutoFindElementsByType() {
            canvas = GameObject.FindObjectOfType<UI_MainCanvas>().gameObject;
            closeCoinShop = GetElement(typeof(CoinShop_CloseCoinShop));
            buyType1 = GetElement(typeof(CoinShop_BuyType1));
            buyType2 = GetElement(typeof(CoinShop_BuyType2));
            buyType3 = GetElement(typeof(CoinShop_BuyType3));
            costTextType1 = GetElement(typeof(CoinShop_CostTextType1));
            costTextType2 = GetElement(typeof(CoinShop_CostTextType2));
            costTextType3 = GetElement(typeof(CoinShop_CostTextType3));
            coinTextType1 = GetElement(typeof(CoinShop_CoinTextType1));
            coinTextType2 = GetElement(typeof(CoinShop_CoinTextType2));
            coinTextType3 = GetElement(typeof(CoinShop_CoinTextType3));
            coin = GetElement(typeof(CoinShop_Coin));
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