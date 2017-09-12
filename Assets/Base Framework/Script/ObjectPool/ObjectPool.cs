using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BaseFramework {
    /// <summary>
    /// Object pool.
    /// </summary>
    public class ObjectPool : MonoBehaviour {
        /// <summary>
        /// The prefab.
        /// </summary>
        public RecycleGameObject prefab;
        /// <summary>
        /// The pool instances.
        /// </summary>
        private List<RecycleGameObject> poolInstances = new List<RecycleGameObject>();
        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <returns>The instance.</returns>
        /// <param name="pos">Position.</param>
        private RecycleGameObject CreateInstance(Vector3 pos) {
            var clone = GameObject.Instantiate(prefab);
            clone.transform.position = pos;
            clone.transform.parent = transform;
            poolInstances.Add(clone);
            return clone;
        }
        /// <summary>
        /// Nexts the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="pos">Position.</param>
        public RecycleGameObject NextObject(Vector3 pos) {
            RecycleGameObject instance = null;
            foreach (var go in poolInstances) {
                if (go.gameObject.activeSelf != true) {
                    instance = go;
                    instance.transform.position = pos;
                }
            }
            if (instance == null)
                instance = CreateInstance(pos);
            instance.Restart();
            return instance;
        }
    }
}