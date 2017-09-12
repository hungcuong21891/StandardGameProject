using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;

namespace BaseFramework {
	[CustomEditor(typeof(AnalyticSetting))]
	public class AnalyticSettingEditor : Editor {
		AnalyticProfile abc;
		private AnalyticSetting analyticSetting;
		/// <summary>
		/// The tab strings.
		/// </summary>
		private string[] TabStrings = new string[] { "Profiles", "Settings"};
		public override void OnInspectorGUI(){
			analyticSetting = (AnalyticSetting)target;
			GUI.changed = false;
			analyticSetting.TabIndex = GUILayout.Toolbar (analyticSetting.TabIndex, TabStrings);
			switch (analyticSetting.TabIndex) {
			case 0:
				Profiles ();
				break;
			case 1:
				Settings ();
				break;
			}
			if (GUI.changed) {
					EditorUtility.SetDirty(analyticSetting);
			}

		}

		void Profiles(){
			EditorGUILayout.LabelField("Fill profiles here", EditorStyles.boldLabel);
			EditorGUILayout.Space();
			EditorGUI.indentLevel++;
			{
				foreach (AnalyticProfile profile in analyticSetting.analyticProfiles) {
					EditorGUILayout.BeginVertical (GUI.skin.box);
					EditorGUILayout.BeginHorizontal ();
					{
						profile.isOpen = EditorGUILayout.Foldout(profile.isOpen, profile.id);
						EditorGUILayout.Space();
						if (GUILayout.Button("X", GUILayout.Width(20))) {
							analyticSetting.analyticProfiles.Remove(profile);
							return;
						}
					}
					EditorGUILayout.EndHorizontal ();
					if (profile.isOpen) {
						//profile id
						EditorGUILayout.BeginHorizontal();
						{
							EditorGUILayout.LabelField("Profile Id");
							profile.id = EditorGUILayout.TextField(profile.id);
						}
						EditorGUILayout.EndHorizontal();
						//platform
						EditorGUILayout.BeginHorizontal();
						{
							EditorGUILayout.LabelField("Platform ");
							profile.platform = (RuntimePlatform)EditorGUILayout.EnumPopup(profile.platform);
						}
						EditorGUILayout.EndHorizontal();
						//choose analytics brand
						EditorGUI.indentLevel++;
						{
							EditorGUILayout.Space ();
							EditorGUILayout.BeginHorizontal();
							{
								profile.isAnalyticsOpen = EditorGUILayout.Foldout(profile.isAnalyticsOpen, "Analytics Networks");
								if (GUILayout.Button("+", EditorStyles.miniButtonLeft, GUILayout.Width(20))) {
									if (profile.analyticProviders.Count < Enum.GetNames (typeof(AnalyticProvider)).Length - 1) {
										profile.analyticProviders.Add (AnalyticProvider.None);
									}
								}
								GUI.enabled = false;
								if (profile.analyticProviders.Count > 0) {
									GUI.enabled = true;
								}
								if (GUILayout.Button("-", EditorStyles.miniButtonRight, GUILayout.Width(20))) {
									if (profile.analyticProviders.Count > 0) {
										profile.analyticProviders.RemoveAt (profile.analyticProviders.Count - 1);
									}
								}
								GUI.enabled = true;
							}
							EditorGUILayout.EndHorizontal();
							bool HorizontalStarted = false;
							if (profile.isAnalyticsOpen) {
								for (int i = 0; i < profile.analyticProviders.Count; i++) {
									if (i % 3 == 0) {
										HorizontalStarted = true;
										EditorGUILayout.BeginHorizontal();
										EditorGUILayout.Space();
									}
									profile.analyticProviders[i] = (AnalyticProvider)EditorGUILayout.EnumPopup(profile.analyticProviders[i], GUILayout.Width(120));
									if ((i + 1) % 3 == 0) {
										HorizontalStarted = false;
										EditorGUILayout.EndHorizontal();
									}
								}
								if (HorizontalStarted) {
									EditorGUILayout.EndHorizontal();
								}
								EditorGUILayout.Space();
							}
						}
						EditorGUI.indentLevel--;
					}
					CheckProfile (profile);
					EditorGUILayout.EndVertical ();
				}
			}
			EditorGUI.indentLevel--;
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.Space();
			if (GUILayout.Button("New Analytic Profile", GUILayout.Width(180))) {
				AnalyticProfile p = new AnalyticProfile();
				analyticSetting.analyticProfiles.Add(p);
			}
			EditorGUILayout.EndHorizontal();
		}
			
		void Settings(){
			EditorGUILayout.Space();
			//Countly
			EditorGUILayout.BeginVertical(GUI.skin.box);
			EditorGUILayout.LabelField("Countly", EditorStyles.boldLabel);
			EditorGUILayout.Space();
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Server:");
			analyticSetting.countlyServer = EditorGUILayout.TextField(analyticSetting.countlyServer);
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("App Key:");
			analyticSetting.countlyAppKey = EditorGUILayout.TextField(analyticSetting.countlyAppKey);
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();
			EditorGUILayout.EndVertical();
		}

		void CheckProfile(AnalyticProfile profile){
			if (HasDuplicates(profile.analyticProviders)) {
				profile.isOpen = true;
				EditorGUILayout.HelpBox("Analytic Providers Has Duplicates Netwroks", MessageType.Error);
			}
		}

		private static bool HasDuplicates<T>(List<T> myList) {
			var hs = new HashSet<T>();
			for (var i = 0; i < myList.Count; ++i) {
				if (!hs.Add(myList[i]))
					return true;
			}
			return false;
		}


	}
}