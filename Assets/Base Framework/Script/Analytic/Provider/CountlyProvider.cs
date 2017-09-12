using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseFramework {
	public class CountlyProvider : CommonAnalyticProvider {
		public void Init(){
			CountlyManager.Instance.appHost = AnalyticController.GetInstance ().analyticSetting.countlyServer;
			CountlyManager.Instance.appKey = AnalyticController.GetInstance ().analyticSetting.countlyAppKey;
			CountlyManager.Init (AnalyticController.GetInstance ().analyticSetting.countlyAppKey);
		}
	
		public void Emit(string key, long count){
			CountlyManager.Emit (key, count);
		}

		public void Emit(string key, long count, Dictionary<string, string> segmentation){
			CountlyManager.Emit (key, count, segmentation);
		}
	}
}
