using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BaseFramework {
    [System.Serializable]
    /// <summary>
    /// Coin pack.
    /// </summary>
    public class CoinPack {
        /// <summary>
        /// The name.
        /// </summary>
        public string name;
        /// <summary>
        /// The cost.
        /// </summary>
        public float cost;
        /// <summary>
        /// The added coin.
        /// </summary>
        public int addedCoin;
    }
    [CreateAssetMenu(fileName = "CoinPack", menuName = "CoinPack/CoinPackInfo", order = 1)]
    /// <summary>
    /// Coin pack information.
    /// </summary>
    public class CoinPackInformation : ScriptableObject {
        /// <summary>
        /// The coin pack1.
        /// </summary>
        public CoinPack coinPack1;
        /// <summary>
        /// The coin pack2.
        /// </summary>
        public CoinPack coinPack2;
        /// <summary>
        /// The coin pack3.
        /// </summary>
        public CoinPack coinPack3;
    }
}