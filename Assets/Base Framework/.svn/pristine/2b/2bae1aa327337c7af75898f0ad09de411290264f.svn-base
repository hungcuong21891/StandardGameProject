using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BaseFramework {
    /// <summary>
    /// Interface for recycle.
    /// </summary>
    public interface IRecycle {
        /// <summary>
        /// Restart this instance.
        /// </summary>
        void Restart();
        /// <summary>
        /// Shutdown this instance.
        /// </summary>
        void Shutdown();
    }
    /// <summary>
    /// Recycle game object.
    /// </summary>
    public class RecycleGameObject : MonoBehaviour {
        /// <summary>
        /// The recycle components.
        /// </summary>
        private List<IRecycle> recycleComponents;
        /// <summary>
        /// Awake this instance.
        /// </summary>
        void Awake() {
            var components = GetComponents<MonoBehaviour>();
            recycleComponents = new List<IRecycle>();
            foreach (var component in components) {
                if (component is IRecycle) {
                    recycleComponents.Add(component as IRecycle);
                }
            }
        }
        /// <summary>
        /// Restart this instance.
        /// </summary>
        public void Restart() {
            gameObject.SetActive(true);
            foreach (var component in recycleComponents) {
                component.Restart();
            }
        }
        /// <summary>
        /// Shutdown this instance.
        /// </summary>
        public void Shutdown() {
            gameObject.SetActive(false);
            foreach (var component in recycleComponents) {
                component.Shutdown();
            }
        }
    }
}