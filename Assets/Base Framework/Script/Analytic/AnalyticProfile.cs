using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseFramework {
	[System.Serializable]
	public class AnalyticProfile {
		public bool isOpen = true;
		public bool isAnalyticsOpen = true;
		public string id = "New Profile";
		public RuntimePlatform platform = RuntimePlatform.Android;
		public List<AnalyticProvider> analyticProviders = new List<AnalyticProvider>();
	}
}
