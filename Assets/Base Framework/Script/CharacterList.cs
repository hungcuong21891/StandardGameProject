using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BaseFramework {
    /// <summary>
    /// Character.
    /// </summary>
    [System.Serializable]
    public class Character {
        /// <summary>
        /// The identifier.
        /// </summary>
        public int id;
        /// <summary>
        /// The cost.
        /// </summary>
        public int cost;
        /// <summary>
        /// The name.
        /// </summary>
        public string name;
        /// <summary>
        /// The sprite.
        /// </summary>
        public Sprite sprite;
        /// <summary>
        /// The default character.
        /// </summary>
        public bool defaultCharacter;
    }
    /// <summary>
    /// Character list.
    /// </summary>
    [CreateAssetMenu(fileName = "Characters", menuName = "Characters/List Characters", order = 1)]
    public class CharacterList : ScriptableObject {
        /// <summary>
        /// The characters.
        /// </summary>
        public List<Character> characters;
    }
}