using UnityEngine;
using UnityEditor;
using System.Collections;
using BaseFramework;

namespace StandardProject {
[CustomEditor(typeof(DetectCollision2D))]
public class DetectCollisionEditor : Editor {
	DetectCollision2D myTarget;
	public override void OnInspectorGUI ()
	{
		//base.OnInspectorGUI ();
		myTarget = (DetectCollision2D) target;
		//tag
		myTarget.tag = EditorGUILayout.TagField("Examine Collide With", myTarget.tag);
		//kind of Collision
		myTarget.kindOfCollision = (KindOfCollision)EditorGUILayout.EnumPopup("Kind Of Collision", myTarget.kindOfCollision);
		//isTrigger
		myTarget.isTrigger = EditorGUILayout.Toggle("IsTrigger", myTarget.isTrigger);
		if (myTarget.isTrigger) {
			//unity event 
			SerializedProperty collisionEvent = serializedObject.FindProperty ("triggeredAction");
			EditorGUILayout.PropertyField (collisionEvent);
			serializedObject.ApplyModifiedProperties ();
		} else {
			//unity event 
			SerializedProperty collisionEvent = serializedObject.FindProperty ("collisionAction");
			EditorGUILayout.PropertyField (collisionEvent);
			serializedObject.ApplyModifiedProperties ();
		}
	}
}
}
