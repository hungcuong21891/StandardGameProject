﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

namespace BaseFramework {
    /// <summary>
    /// Purchaser.
    /// </summary>
    public class Purchaser : Singleton<Purchaser>, IStoreListener {
        /// <summary>
        /// The m store controller.
        /// </summary>
        private static IStoreController m_StoreController;
        /// <summary>
        /// The m store extension provider.
        /// </summary>
        private static IExtensionProvider m_StoreExtensionProvider;
        /// <summary>
        /// The iap data.
        /// </summary>
        public IAPData iapData;
        /// <summary>
        /// Initialize this instance.
        /// </summary>
        protected override void Initialize() {

        }
        /// <summary>
        /// Start this instance.
        /// </summary>
        void Start() {
            // If we haven't set up the Unity Purchasing reference
            if (m_StoreController == null) {
                // Begin to configure our connection to Purchasing
                InitializePurchasing();
            }
        }
        /// <summary>
        /// Initializes the purchasing.
        /// </summary>
        public void InitializePurchasing() {
            // If we have already connected to Purchasing ...
            if (IsInitialized()) {
                // ... we are done here.
                return;
            }

            // Create a builder, first passing in a suite of Unity provided stores.
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            for (int i = 0; i < iapData.listProduct.Count; i++) {
                IAPProduct product = iapData.listProduct[i];
                builder.AddProduct(product.productName, product.productType, new IDs() {
                {
                    product.iosSKU,
                    AppleAppStore.Name
                },
                {
                    product.androidSKU,
                    GooglePlay.Name
                },
            });

            }
            UnityPurchasing.Initialize(this, builder);
        }
        /// <summary>
        /// Determines whether this instance is initialized.
        /// </summary>
        /// <returns><c>true</c> if this instance is initialized; otherwise, <c>false</c>.</returns>
        private bool IsInitialized() {
            // Only say we are initialized if both the Purchasing references are set.
            return m_StoreController != null && m_StoreExtensionProvider != null;
        }
        /// <summary>
        /// Buies the product I.
        /// </summary>
        /// <param name="productId">Product identifier.</param>
        public void BuyProductID(string productId) {
            // If the stores throw an unexpected exception, use try..catch to protect my logic here.
            try {
                // If Purchasing has been initialized ...
                if (IsInitialized()) {
                    // ... look up the Product reference with the general product identifier and the Purchasing system's products collection.
                    Product product = m_StoreController.products.WithID(productId);

                    // If the look up found a product for this device's store and that product is ready to be sold ... 
                    if (product != null && product.availableToPurchase) {
                        Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));// ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
                        m_StoreController.InitiatePurchase(product);
                    }
                    // Otherwise ...
                    else {
                        // ... report the product look-up failure situation  
                        Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                    }
                }
                // Otherwise ...
                else {
                    // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or retrying initiailization.
                    Debug.Log("BuyProductID FAIL. Not initialized.");
                }
            }
            // Complete the unexpected exception handling ...
            catch (Exception e) {
                // ... by reporting any unexpected exception for later diagnosis.
                Debug.Log("BuyProductID: FAIL. Exception during purchase. " + e);
            }
        }
        /// <summary>
        /// Restores the purchases.
        /// </summary>
        public void RestorePurchases() {
            // If Purchasing has not yet been set up ...
            if (!IsInitialized()) {
                // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
                Debug.Log("RestorePurchases FAIL. Not initialized.");
                return;
            }

            // If we are running on an Apple device ... 
            if (Application.platform == RuntimePlatform.IPhonePlayer ||
                Application.platform == RuntimePlatform.OSXPlayer) {
                // ... begin restoring purchases
                Debug.Log("RestorePurchases started ...");

                // Fetch the Apple store-specific subsystem.
                var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
                // Begin the asynchronous process of restoring purchases. Expect a confirmation response in the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
                apple.RestoreTransactions((result) => {
                    // The first phase of restoration. If no more responses are received on ProcessPurchase then no purchases are available to be restored.
                    Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
                });
            }
            // Otherwise ...
            else {
                // We are not running on an Apple device. No work is necessary to restore purchases.
                Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
            }
        }
        /// <summary>
        /// Raises the initialized event.
        /// </summary>
        /// <param name="controller">Controller.</param>
        /// <param name="extensions">Extensions.</param>
        public void OnInitialized(IStoreController controller, IExtensionProvider extensions) {
            // Purchasing has succeeded initializing. Collect our Purchasing references.
            Debug.Log("OnInitialized: PASS");

            // Overall Purchasing system, configured with products for this application.
            m_StoreController = controller;
            // Store specific subsystem, for accessing device-specific store features.
            m_StoreExtensionProvider = extensions;
        }
        /// <summary>
        /// Raises the initialize failed event.
        /// </summary>
        /// <param name="error">Error.</param>
        public void OnInitializeFailed(InitializationFailureReason error) {
            // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
            Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
        }
        /// <summary>
        /// Processes the purchase.
        /// </summary>
        /// <returns>The purchase.</returns>
        /// <param name="args">Arguments.</param>
        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) {
            // A consumable product has been purchased by this user.
            for (int i = 0; i < iapData.listProduct.Count; i++) {
                IAPProduct product = iapData.listProduct[i];
                if (String.Equals(args.purchasedProduct.definition.id, product.productName, StringComparison.Ordinal)) {
                    Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));//If the consumable item has been successfully purchased, add coins to the player
                    EventManager.TriggerEvent(product.productName, null);
                }
            }
            // Return a flag indicating wither this product has completely been received, or if the application needs to be reminded of this purchase at next app launch. Is useful when saving purchased products to the cloud, and when that save is delayed.
            return PurchaseProcessingResult.Complete;
        }
        /// <summary>
        /// Raises the purchase failed event.
        /// </summary>
        /// <param name="product">Product.</param>
        /// <param name="failureReason">Failure reason.</param>
        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) {
            // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing this reason with the user.
            Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
        }
    }
}