using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using BaseFramework;

namespace StandardProject{
public enum KindOfCollision{
	ENTER,
	STAY,
	EXIT
}

[System.Serializable]
public class TriggerEvent : UnityEvent<Collider2D> {}

[System.Serializable]
public class CollisionEvent : UnityEvent<Collision2D> {}

public class DetectCollision2D: MonoBehaviour {
	public KindOfCollision kindOfCollision = KindOfCollision.ENTER;
	public TriggerEvent triggeredAction;
	public CollisionEvent collisionAction;
	public bool isUsing = true;
	public bool isTrigger = true;
	public string tag;

	void OnTriggerEnter2D(Collider2D coll){
		if (kindOfCollision == KindOfCollision.ENTER) {
			if (isTrigger && isUsing) {
				if (coll.gameObject.tag == tag || tag == "Any") {
					triggeredAction.Invoke (coll);
				}
			}
		}
	}

	void OnTriggerStay2D(Collider2D coll){
		if (kindOfCollision == KindOfCollision.STAY) {
			if (isTrigger && isUsing) {
				if (coll.gameObject.tag == tag || tag == "Any") {
					triggeredAction.Invoke (coll);
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		if (kindOfCollision == KindOfCollision.EXIT) {
			if (isTrigger && isUsing) {
				if (coll.gameObject.tag == tag || tag == "Any") {
					triggeredAction.Invoke (coll);
				}
			}
		}
	}
		
	void OnCollisionEnter2D(Collision2D coll){
		if (kindOfCollision == KindOfCollision.ENTER) {
			if (!isTrigger && isUsing) {
				if (coll.gameObject.tag == tag || tag == "Any") {
					collisionAction.Invoke (coll);
				}
			}
		}
	}

	void OnCollisionStay2D(Collision2D coll){
		if (kindOfCollision == KindOfCollision.STAY) {
			if (!isTrigger && isUsing) {
				if (coll.gameObject.tag == tag || tag == "Any") {
					collisionAction.Invoke (coll);
				}
			}
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		if (kindOfCollision == KindOfCollision.EXIT) {
			if (!isTrigger && isUsing) {
				if (coll.gameObject.tag == tag || tag == "Any") {
					collisionAction.Invoke (coll);
				}
			}
		}
	}
}
}
