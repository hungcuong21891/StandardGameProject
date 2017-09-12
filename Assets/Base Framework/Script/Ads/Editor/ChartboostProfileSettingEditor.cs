using UnityEngine;
using System.Collections;
using UnityEditor;
using ChartboostSDK;
/// <summary>
/// Chart boost profile setting editor.
/// </summary>
public class ChartBoostProfileSettingEditor{
	/// <summary>
	/// Draws the settings.
	/// </summary>
	public static void DrawSettings() {
		EditorGUILayout.Space();

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.Space();
		if(GUILayout.Button("Open Chartboost Settings",  GUILayout.Width(250))) {
		CBSettings.Edit();
		}
		EditorGUILayout.Space();
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.Space();
	}
}
