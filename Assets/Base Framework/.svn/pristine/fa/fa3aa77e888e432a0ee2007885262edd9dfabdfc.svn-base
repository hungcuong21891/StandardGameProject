using UnityEngine;

namespace BaseFramework {
    /// <summary>
    /// Singleton.
    /// </summary>
    public abstract class Singleton<T_TYPE> : MonoBehaviour where T_TYPE : Singleton<T_TYPE> {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>The instance.</returns>
        public static T_TYPE GetInstance() {
            if (_instance == null) {
                _instance = GameObject.FindObjectOfType(typeof(T_TYPE)) as T_TYPE;
            }
            return _instance;
        }
        /// <summary>
        /// Initialize this instance.
        /// </summary>
        protected abstract void Initialize();
        /// <summary>
        /// Awake this instance.
        /// </summary>
        private void Awake() {
            T_TYPE instance = GetInstance();
            if (instance == null) {
                instance = this as T_TYPE;
            }
            if (instance != (this as T_TYPE)) {
                Destroy(gameObject);
                return;
            }
            _instance = instance;
            Initialize();
            GameObject.DontDestroyOnLoad(gameObject);
        }
        /// <summary>
        /// The instance.
        /// </summary>
        private static T_TYPE _instance = null;
    }
}