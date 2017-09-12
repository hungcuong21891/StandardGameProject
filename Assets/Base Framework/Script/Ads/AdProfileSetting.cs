using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BaseFramework {
    /// <summary>
    /// Choose profile policy.
    /// </summary>
    public enum ChooseProfilePolicy {
        FIRST,
        EXACT_ID
    }
    /// <summary>
    /// Choose provider policy.
    /// </summary>
    public enum ChooseProviderPolicy {
        KEEP_THE_LAST,
        ROLL,
        ALWAYS_FROM_FIRST
    }
    /// <summary>
    /// GAD test device.
    /// </summary>
    [System.Serializable]
    public class GADTestDevice {
        /// <summary>
        /// The name.
        /// </summary>
        public string Name = "[New Test Device]";
        /// <summary>
        /// The I.
        /// </summary>
        public string ID = "put your device id here";
        /// <summary>
        /// The is open.
        /// </summary>
        public bool IsOpen = false;
    }
    /// <summary>
    /// Ad profile setting.
    /// </summary>
    [CreateAssetMenu(fileName = "AdProfileSetting", menuName = "Ads/Profile Setting", order = 2)]
    public class AdProfileSetting : ScriptableObject {
        /// <summary>
        /// The index of the tab.
        /// </summary>
        public int TabIndex = 0;
        /// <summary>
        /// The ad profiles.
        /// </summary>
        public List<AdProfile> adProfiles = new List<AdProfile>();
		/*************UNITY_ADS*********************/
        /// <summary>
        /// The unity ads iOS ID.
        /// </summary>
        public string UnityAds_IOS_ID = string.Empty;
        /// <summary>
        /// The unity ads android ID.
        /// </summary>
        public string UnityAds_Android_ID = string.Empty;
		/*************FACEBOOK*********************/
		public string FacebookPlacement_ID = string.Empty;
		/*************APP_LOVIN*********************/
		/// <summary>
		/// The app lovin ID.
		/// </summary>
		public string AppLovin_ID = string.Empty;
		/*************LEADBOLT*********************/
		/// <summary>
		/// The leadbolt ID.
		/// </summary>
		/// 
		public string Leadbolt_ID = string.Empty;
		/*************Vungle*********************/
        /// <summary>
        /// The vungle iOS ID
        /// </summary>
        public string Vungle_IOS_ID = string.Empty;
        /// <summary>
        /// The vungle android ID.
        /// </summary>
        public string Vungle_Android_ID = string.Empty;
		/*************ADMOB*********************/
        /// <summary>
        /// The admob iOS interstisial identifier.
        /// </summary>
        public string Admob_IOS_Interstisial_Id = string.Empty;
        /// <summary>
        /// The admob iOS banner identifier.
        /// </summary>
        public string Admob_IOS_Banner_Id = string.Empty;
		/// <summary>
		/// The admob IO s video identifier.
		/// </summary>
		public string Admob_IOS_Video_Id = string.Empty;
        /// <summary>
        /// The admob android interstisial identifier.
        /// </summary>
        public string Admob_Android_Interstisial_Id = string.Empty;
        /// <summary>
        /// The admob android banner identifier.
        /// </summary>
        public string Admob_Android_Banner_Id = string.Empty;
		/// <summary>
		/// The admob android video identifier.
		/// </summary>
		public string Admob_Android_Video_Id = string.Empty;
        /// <summary>
        /// The is test devices opened.
        /// </summary>
        public bool IsTestDevicesOpened = true;
        /// <summary>
        /// The test devices.
        /// </summary>
        [SerializeField]
        public List<GADTestDevice> testDevices = new List<GADTestDevice>();
        /// <summary>
        /// The choose profile policy.
        /// </summary>
        public ChooseProfilePolicy chooseProfilePolicy = ChooseProfilePolicy.FIRST;
        /// <summary>
        /// The choose provider policy.
        /// </summary>
        public ChooseProviderPolicy chooseProviderPolicy = ChooseProviderPolicy.KEEP_THE_LAST;
        /// <summary>
        /// The profile identifier.
        /// </summary>
        public string profileId;
        /// <summary>
        /// The video load time out.
        /// </summary>
        public float videoLoadTimeOut = 10f;
        /// <summary>
        /// The interstisial load time out.
        /// </summary>
        public float interstisialLoadTimeOut = 10f;
    }
}