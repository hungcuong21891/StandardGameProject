using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace BaseFramework {
    /// <summary>
    /// Event manager.
    /// </summary>
    public class EventManager : MonoBehaviour {
        /// <summary>
        /// The event dictionary.
        /// </summary>
        private Dictionary<string, MyUnityEvent> eventDictionary;
        /// <summary>
        /// The event manager.
        /// </summary>
        private static EventManager eventManager;
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static EventManager instance {
            get {
                if (!eventManager) {
                    eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;
                    if (!eventManager) {
                        Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                    } else {
                        eventManager.Init();
                    }
                }
                return eventManager;
            }
        }
        /// <summary>
        /// Init this instance.
        /// </summary>
        void Init() {
            if (eventDictionary == null) {
                eventDictionary = new Dictionary<string, MyUnityEvent>();
            }
        }
        /// <summary>
        /// Starts the listening.
        /// </summary>
        /// <param name="eventName">Event name.</param>
        /// <param name="listener">Listener.</param>
        public static void StartListening(string eventName, UnityAction<EventInfo> listener) {
            MyUnityEvent thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
                thisEvent.AddListener(listener);
            } else {
                thisEvent = new MyUnityEvent();
                thisEvent.AddListener(listener);
                instance.eventDictionary.Add(eventName, thisEvent);
            }
        }
        /// <summary>
        /// Stops the listening.
        /// </summary>
        /// <param name="eventName">Event name.</param>
        /// <param name="listener">Listener.</param>
        public static void StopListening(string eventName, UnityAction<EventInfo> listener) {
            if (eventManager == null)
                return;
            MyUnityEvent thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
                thisEvent.RemoveListener(listener);
            }
        }
        /// <summary>
        /// Triggers the event.
        /// </summary>
        /// <param name="eventName">Event name.</param>
        /// <param name="arg">Argument.</param>
        public static void TriggerEvent(string eventName, EventInfo arg) {
            MyUnityEvent thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
                thisEvent.Invoke(arg);
            }
        }
    }
}