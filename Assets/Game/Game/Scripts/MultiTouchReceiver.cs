using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BaseFramework;

namespace StandardProject{
[System.Serializable]
public class BeginEvent : UnityEvent<Vector3>{}
public class MultiTouchReceiver : MonoBehaviour {
	public BeginEvent touchDownEvent;
	public BeginEvent touchMoveEvent;
	public BeginEvent touchEndedEvent;

	void Update () 
	{
		Touch[] myTouches = Input.touches;
		for(int i = 0; i < Input.touchCount; i++)
		{
			if (Input.GetTouch (i).phase == TouchPhase.Began) {
				touchDownEvent.Invoke (Input.GetTouch(i).position);
			} 
			if (Input.GetTouch (i).phase == TouchPhase.Moved) {
				touchMoveEvent.Invoke (Input.GetTouch(i).position);
			}
			if (Input.GetTouch (i).phase == TouchPhase.Ended) {
				touchEndedEvent.Invoke (Input.GetTouch(i).position);
			}

		}
	}
}
}
