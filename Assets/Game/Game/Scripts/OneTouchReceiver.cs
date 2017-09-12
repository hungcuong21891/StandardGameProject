using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using BaseFramework;

namespace StandardProject{
public class OneTouchReceiver : MonoBehaviour {
	public bool checkIfHitThisGameObject;
	public BeginEvent eventWhenTouchDown;
	public BeginEvent eventWhenTouchDrag;
	public BeginEvent eventWhenTouchUp;
	private bool isEnabled;
	// Use this for initialization
	void Start () {
		isEnabled = true;
		EventManager.StartListening ("DisableInput", DisableInput);
		EventManager.StartListening ("EnableInput", EnableInput);
	}

	// Update is called once per frame
	void Update () {
		if (isEnabled) {
			if (Input.GetMouseButtonDown (0)) {
				if (checkIfHitThisGameObject){
					Vector2 pos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
					RaycastHit2D hitInfo = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (pos), Vector2.zero);
					// RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
					if (hitInfo) {
							if (hitInfo.transform.gameObject == gameObject) {
								eventWhenTouchDown.Invoke (Input.mousePosition);;
							}
					} 
				} else {
					eventWhenTouchDown.Invoke (Input.mousePosition);;
				}
			}
			if (Input.GetMouseButton (0)) {
				if (checkIfHitThisGameObject){
					Vector2 pos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
					RaycastHit2D hitInfo = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (pos), Vector2.zero);
					// RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
					if (hitInfo) {
						if (hitInfo.transform.gameObject == gameObject) {
							eventWhenTouchDrag.Invoke (Input.mousePosition);;
						}
					} 
				} else {
					eventWhenTouchDrag.Invoke (Input.mousePosition);;
				}
			}
			if (Input.GetMouseButtonUp (0)) {
				if (checkIfHitThisGameObject){
					Vector2 pos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
					RaycastHit2D hitInfo = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (pos), Vector2.zero);
					// RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
					if (hitInfo) {
						if (hitInfo.transform.gameObject == gameObject) {
							eventWhenTouchUp.Invoke (Input.mousePosition);;
						}
					} 
				} else {
					eventWhenTouchUp.Invoke (Input.mousePosition);;
				}
			}
		}
	}

	void DisableInput(EventInfo info){
		isEnabled = false;
	}

	void EnableInput(EventInfo info){
		isEnabled = true;
	}

}
}
