using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BaseFramework {
    /// <summary>
    /// Game object util.
    /// </summary>
    public class GameObjectUtil {
        /// <summary>
        /// The pools.
        /// </summary>
        private static Dictionary<RecycleGameObject, ObjectPool> pools = new Dictionary<RecycleGameObject, ObjectPool>();
        /// <summary>
        /// Instantiate the specified prefab and pos.
        /// </summary>
        /// <param name="prefab">Prefab.</param>
        /// <param name="pos">Position.</param>
        public static GameObject Instantiate(GameObject prefab, Vector3 pos, Transform parent = null) {
            GameObject instance = null;
            var recycledScript = prefab.GetComponent<RecycleGameObject>();
            if (recycledScript != null) {
                var pool = GetObjectPool(recycledScript);
                instance = pool.NextObject(pos).gameObject;
            } else {
                instance = GameObject.Instantiate(prefab);
                instance.transform.position = pos;
            }
            if (parent != null) {
                instance.transform.parent = parent;
            }
            return instance;
        }
        /// <summary>
        /// Destroy the specified gameObject.
        /// </summary>
        /// <param name="gameObject">Game object.</param>
        public static void Destroy(GameObject gameObject) {
            var recycleGameObject = gameObject.GetComponent<RecycleGameObject>();
            if (recycleGameObject != null) {
                recycleGameObject.Shutdown();
            } else {
                GameObject.Destroy(gameObject);
            }
        }
        /// <summary>
        /// Gets the object pool.
        /// </summary>
        /// <returns>The object pool.</returns>
        /// <param name="reference">Reference.</param>
        private static ObjectPool GetObjectPool(RecycleGameObject reference) {
            ObjectPool pool = null;
            if (pools.ContainsKey(reference)) {
                pool = pools[reference];
            } else {
                var poolContainer = new GameObject(reference.gameObject.name + "ObjectPool");
                pool = poolContainer.AddComponent<ObjectPool>();
                pool.prefab = reference;
                pools.Add(reference, pool);
            }
            return pool;
        }
        /// <summary>
        /// Destroies the object pool.
        /// </summary>
        public static void DestroyObjectPool() {
            pools.Clear();
        }
    }
}