using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BaseFramework {
    /// <summary>
    /// Player manager.
    /// </summary>
    public class PlayerManager : Singleton<PlayerManager> {
        /// <summary>
        /// The player coin.
        /// </summary>
        public int playerCoin;
        /// <summary>
        /// The name of the player.
        /// </summary>
        public int playerName;
        /// <summary>
        /// The number characters unlock.
        /// </summary>
        public int numCharactersUnlock;
        /// <summary>
        /// The unlock characters.
        /// </summary>
        public int[] unlockCharacters;
        /// <summary>
        /// The select character.
        /// </summary>
        public int selectCharacter;
        /// <summary>
        /// The best score.
        /// </summary>
        public int bestScore;
        /// <summary>
        /// The best score float.
        /// </summary>
        public float bestScoreFloat;
        /// <summary>
        /// The best campaign.
        /// </summary>
        public int bestCampaign;
        /// <summary>
        /// The sound on.
        /// </summary>
        public int soundOn;
        /// <summary>
        /// The kid mode on.
        /// </summary>
        public int kidModeOn;
        /// <summary>
        /// The best score level.
        /// </summary>
        public int[] bestScoreLevel;
        /// <summary>
        /// The best score level float.
        /// </summary>
        public float[] bestScoreLevelFloat;
        /// <summary>
        /// Initialize this instance.
        /// </summary>
        protected override void Initialize() {
            //		PlayerPrefs.DeleteAll ();
            UpdateInfo();
            Debug.Log("NumCharactersUnlock: " + numCharactersUnlock);
            for (int i = 0; i < 4; i++) {
                Debug.Log("UnlockChar" + i + ": " + unlockCharacters[i]);
            }
        }
        /// <summary>
        /// Updates the info.
        /// </summary>
        void UpdateInfo() {
            if (PlayerPrefs.HasKey("Coin")) {
                playerCoin = PlayerPrefs.GetInt("Coin");
            } else {
                playerCoin = 0;
                PlayerPrefs.SetInt("Coin", 0);
            }
            numCharactersUnlock = PlayerPrefs.GetInt("NumChar");
            unlockCharacters = PlayerPrefsX.GetIntArray("UnlockCharacters", -1, 100);
            selectCharacter = PlayerPrefs.GetInt("SelectCharacter");
            if (GameManager.GetInstance().gameInformation.smallerScoreIsBetter) {
                bestScore = PlayerPrefs.GetInt("BestScore", 99999999);
                bestScoreFloat = PlayerPrefs.GetFloat("BestScoreFloat", 99999999.0f);
                bestScoreLevel = PlayerPrefsX.GetIntArray("BestScoreLevel", 99999999, 100);
                bestScoreLevelFloat = PlayerPrefsX.GetFloatArray("BestScoreLevelFloat", 99999999.0f, 100);
            } else {
                bestScore = PlayerPrefs.GetInt("BestScore", -9999999);
                bestScoreFloat = PlayerPrefs.GetFloat("BestScoreFloat", -99999999.0f);
                bestScoreLevel = PlayerPrefsX.GetIntArray("BestScoreLevel", -99999999, 100);
                bestScoreLevelFloat = PlayerPrefsX.GetFloatArray("BestScoreLevelFloat", -99999999.0f, 100);
            }
            bestCampaign = PlayerPrefs.GetInt("BestCampaign");
            if (PlayerPrefs.HasKey("SoundOn")) {
                soundOn = PlayerPrefs.GetInt("SoundOn");
            } else {
                soundOn = 1;
                PlayerPrefs.SetInt("SoundOn", 1);
            }

            if (PlayerPrefs.HasKey("KidModeOn")) {
                kidModeOn = PlayerPrefs.GetInt("KidModeOn");
            } else {
                kidModeOn = 0;
                PlayerPrefs.SetInt("KidModeOn", 0);
            }

            //default
            if (numCharactersUnlock == 0) {
                DefaultCharacters();
                SyncInfo();
            }
        }
        /// <summary>
        /// Defaults the characters.
        /// </summary>
        void DefaultCharacters() {
            if (CharacterManager.GetInstance().listOfCharacters != null) {
                var allCharacters = CharacterManager.GetInstance().listOfCharacters.characters;
                for (int i = 0; i < allCharacters.Count; i++) {
                    Character character = allCharacters[i];
                    if (character.defaultCharacter == true) {
                        unlockCharacters[numCharactersUnlock] = character.id;
                        numCharactersUnlock += 1;
                    }
                }
                selectCharacter = unlockCharacters[0];
            }
        }
        /// <summary>
        /// Syncs the info.
        /// </summary>
        public void SyncInfo() {
            PlayerPrefsX.SetIntArray("UnlockCharacters", unlockCharacters);
            PlayerPrefs.SetInt("Coin", playerCoin);
            PlayerPrefs.SetInt("NumChar", numCharactersUnlock);
            PlayerPrefs.SetInt("SelectCharacter", selectCharacter);
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.SetFloat("BestScoreFloat", bestScoreFloat);
            PlayerPrefsX.SetIntArray("BesScoreLevel", bestScoreLevel);
            PlayerPrefsX.SetFloatArray("BestScoreLevelFloat", bestScoreLevelFloat);
            PlayerPrefs.SetInt("BestCampaign", bestCampaign);
            PlayerPrefs.SetInt("SoundOn", soundOn);
            PlayerPrefs.SetInt("KidModeOn", kidModeOn);
        }
        /// <summary>
        /// Determines whether this instance is unlock character the specified id.
        /// </summary>
        /// <returns><c>true</c> if this instance is unlock character the specified id; otherwise, <c>false</c>.</returns>
        /// <param name="id">Identifier.</param>
        public bool IsUnlockCharacter(int id) {
            for (int i = 0; i < unlockCharacters.Length; i++) {
                if (id == unlockCharacters[i]) {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Adds the unlock characters.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void AddUnlockCharacters(int id) {
            unlockCharacters[numCharactersUnlock] = id;
            numCharactersUnlock += 1;
            SyncInfo();
        }
        /// <summary>
        /// Adds the coin.
        /// </summary>
        /// <param name="deltaCoin">Delta coin.</param>
        public void AddCoin(int deltaCoin) {
            playerCoin += deltaCoin;
            SyncInfo();
        }
        /// <summary>
        /// Updates the coin.
        /// </summary>
        /// <param name="newCoin">New coin.</param>
        public void UpdateCoin(int newCoin) {
            playerCoin = newCoin;
            SyncInfo();
        }
        /// <summary>
        /// Sets the coin.
        /// </summary>
        /// <param name="coin">Coin.</param>
        public void SetCoin(int coin) {
            playerCoin = coin;
            SyncInfo();
        }
        /// <summary>
        /// Selects the character.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void SelectCharacter(int id) {
            selectCharacter = id;
            SyncInfo();
        }
        /// <summary>
        /// Updates the best score.
        /// </summary>
        /// <param name="newBestScore">New best score.</param>
        public void UpdateBestScore(int newBestScore) {
            bestScore = newBestScore;
            SyncInfo();
        }
        /// <summary>
        /// Updates the best score float.
        /// </summary>
        /// <param name="newBestScoreFloat">New best score float.</param>
        public void UpdateBestScoreFloat(float newBestScoreFloat) {
            bestScoreFloat = newBestScoreFloat;
            SyncInfo();
        }
        /// <summary>
        /// Updates the best campaign.
        /// </summary>
        /// <param name="bestCamp">Best camp.</param>
        public void UpdateBestScoreLevel(int id, int score) {
            bestScoreLevel[id] = score;
            SyncInfo();
        }
        /// <summary>
        /// Updates the best score level float.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="score">Score.</param>
        public void UpdateBestScoreLevelFloat(int id, float score) {
            bestScoreLevelFloat[id] = score;
            SyncInfo();
        }
        /// <summary>
        /// Updates the best campaign.
        /// </summary>
        /// <param name="bestCamp">Best camp.</param>
        public void UpdateBestCampaign(int bestCamp) {
            bestCampaign = bestCamp;
            SyncInfo();
        }
        /// <summary>
        /// Updates the sound on.
        /// </summary>
        /// <param name="sound">Sound.</param>
        public void UpdateSoundOn(int sound) {
            soundOn = sound;
            SyncInfo();
        }
        /// <summary>
        /// Updates the kid mode.
        /// </summary>
        /// <param name="kidMode">Kid mode.</param>
        public void UpdateKidMode(int kidMode) {
            kidModeOn = kidMode;
            SyncInfo();
        }
        /// <summary>
        /// Removes the ads.
        /// </summary>
        public void RemoveAds() {
            PlayerPrefsX.SetBool("RemoveAds", true);
        }
    }
}