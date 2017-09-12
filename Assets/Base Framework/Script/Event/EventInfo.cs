using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BaseFramework {
    /// <summary>
    /// Event info.
    /// </summary>
    public class EventInfo {
        /// <summary>
        /// The event integer.
        /// </summary>
        public Dictionary<string, int> eventInteger;
        /// <summary>
        /// The event float.
        /// </summary>
        public Dictionary<string, float> eventFloat;
        /// <summary>
        /// The event string.
        /// </summary>
        public Dictionary<string, string> eventString;
        /// <summary>
        /// The event bool.
        /// </summary>
        public Dictionary<string, bool> eventBool;
        /// <summary>
        /// The event vector3.
        /// </summary>
        public Dictionary<string, Vector3> eventVector3;
        /// <summary>
        /// The event vector2.
        /// </summary>
        public Dictionary<string, Vector2> eventVector2;
        /// <summary>
        /// The color of the event.
        /// </summary>
        public Dictionary<string, Color> eventColor;
        /// <summary>
        /// The event objects.
        /// </summary>
        public Dictionary<string, GameObject> eventObjects;
		/// <summary>
		/// The event list objects.
		/// </summary>
		public Dictionary<string, List<GameObject>> eventListObjects;
        /// <summary>
        /// The event object.
        /// </summary>
        public GameObject eventObject;
        /// <summary>
        /// Initializes a new instance of the <see cref="EventInfo"/> class.
        /// </summary>
        public EventInfo() {
            eventInteger = new Dictionary<string, int>();
            eventFloat = new Dictionary<string, float>();
            eventString = new Dictionary<string, string>();
            eventBool = new Dictionary<string, bool>();
            eventColor = new Dictionary<string, Color>();
            eventVector2 = new Dictionary<string, Vector2>();
            eventVector3 = new Dictionary<string, Vector3>();
            eventObjects = new Dictionary<string, GameObject>();
			eventListObjects = new Dictionary<string, List<GameObject>> ();
            eventObject = null;
        }
    }
}