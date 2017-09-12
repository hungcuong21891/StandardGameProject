using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseFramework {
	public class AnalyticController : Singleton<AnalyticController> {
		public AnalyticSetting analyticSetting;

		private List<CommonAnalyticProvider> analyticProviders = new List<CommonAnalyticProvider> ();

		protected override void Initialize() {
			AnalyticProfile profile = null;
			foreach (AnalyticProfile p in analyticSetting.analyticProfiles) {
					//highest priority is the first profile that has same platform
					if (p.platform.Equals(Application.platform)) {
						profile = p;
						break;
					}
				#if UNITY_EDITOR
				profile = p;
				break;
				#endif
			}
			Init (profile);

		}
		void Init(AnalyticProfile profile) {
			if (profile == null) {
				Debug.LogWarning("Null Profile");
				return;
			}
			foreach (AnalyticProvider provider in profile.analyticProviders) {
				DefineAnalyticProvider(provider);
			}
		}

		private void DefineAnalyticProvider(AnalyticProvider ip) {
			CommonAnalyticProvider provider = null;
			switch (ip) {
			case AnalyticProvider.Countly:
				provider = new CountlyProvider ();
				break;
			}
			if (provider != null) {
				analyticProviders.Add(provider);
				provider.Init ();
			}
		}

		public void Emit(string key, long count){
			foreach (var provider in analyticProviders) {
				provider.Emit (key, count);
			}
		}

		public void Emit(string key, long count, Dictionary<string, string> segmentation){
			foreach (var provider in analyticProviders) {
				provider.Emit (key, count, segmentation);
			}
		}
	}
}