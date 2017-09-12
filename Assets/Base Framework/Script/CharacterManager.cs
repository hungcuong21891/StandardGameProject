using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace BaseFramework {
    /// <summary>
    /// Character manager.
    /// </summary>
    public class CharacterManager : Singleton<CharacterManager> {
        /// <summary>
        /// The characters.
        /// </summary>
        public CharacterList listOfCharacters;
        /// <summary>
        /// Initialize this instance.
        /// </summary>
        protected override void Initialize() {

        }
        /// <summary>
        /// Gets the character with identifier.
        /// </summary>
        /// <returns>The character with identifier.</returns>
        /// <param name="id">Identifier.</param>
        public Character GetCharacterWithId(int id) {
            for (int i = 0; i < listOfCharacters.characters.Count; i++) {
                Character currentCharacter = listOfCharacters.characters[i];
                if (currentCharacter.id == id) {
                    return currentCharacter;
                }
            }
            return null;
        }
    }
}