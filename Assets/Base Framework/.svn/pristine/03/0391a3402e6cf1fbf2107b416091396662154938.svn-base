using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;

namespace BaseFramework {
    /// <summary>
    /// Platform.
    /// </summary>
    public enum Platform {
        ANDROID,
        IOS
    }
    /// <summary>
    /// IAP product.
    /// </summary>
    [System.Serializable]
    public class IAPProduct {
        /// <summary>
        /// The name of the product.
        /// </summary>
        public string productName;
        /// <summary>
        /// The type of the product.
        /// </summary>
        public ProductType productType;
        [Header("SKU of each platform")]
        /// <summary>
        /// The ios SKU.
        /// </summary>
        public string iosSKU;
        /// <summary>
        /// The android SKU.
        /// </summary>
        public string androidSKU;
    }
    /// <summary>
    /// IAP data.
    /// </summary>
    [CreateAssetMenu(fileName = "IAPData", menuName = "In App Purchase", order = 1)]
    public class IAPData : ScriptableObject {
        /// <summary>
        /// The list product.
        /// </summary>
        public List<IAPProduct> listProduct;
        /// <summary>
        /// Gets the name of the identifier by product.
        /// </summary>
        /// <returns>The identifier by product name.</returns>
        /// <param name="name">Name.</param>
        /// <param name="platform">Platform.</param>
        public string GetIdByProductName(string name, Platform platform) {
            foreach (IAPProduct element in listProduct) {
                if (name.Equals(element.productName)) {
                    if (platform == Platform.ANDROID) {
                        return element.androidSKU;
                    } else if (platform == Platform.IOS) {
                        return element.iosSKU;
                    }
                }
            }
            return null;
        }
    }
}