using UnityEngine;
using System.Collections;

namespace BaseFramework {
    /// <summary>
    /// Sound manager.
    /// </summary>
    public class SoundManager : Singleton<SoundManager> {
        /// <summary>
        /// The efx source.
        /// </summary>
        public AudioSource efxSource;
        /// <summary>
        /// The music source.
        /// </summary>
        public AudioSource musicSource;
        /// <summary>
        /// The low pitch range.
        /// </summary>
        public float lowPitchRange = .95f;
        /// <summary>
        /// The high pitch range.
        /// </summary>
        public float highPitchRange = 1.05f;
        /// <summary>
        /// The buy sound.
        /// </summary>
        public AudioClip buySound;
        /// <summary>
        /// The click sound.
        /// </summary>
        public AudioClip clickSound;
        /// <summary>
        /// The open menu.
        /// </summary>
        public AudioClip openMenu;
        /// <summary>
        /// The clear campaign.
        /// </summary>
        public AudioClip clearCampaign;
        /// <summary>
        /// The high score.
        /// </summary>
        public AudioClip highScore;
        /// <summary>
        /// The efx volume.
        /// </summary>
        private float efxVolume;
        /// <summary>
        /// The music volume.
        /// </summary>
        private float musicVolume;
        /// <summary>
        /// The sound on.
        /// </summary>
        private int soundOn;
        /// <summary>
        /// Initialize this instance.
        /// </summary>
        protected override void Initialize() {
            efxVolume = efxSource.volume;
            musicVolume = musicSource.volume;

        }
        /// <summary>
        /// Start this instance.
        /// </summary>
        void Start() {
            soundOn = PlayerManager.GetInstance().soundOn;
            if (soundOn == 0) {
                DisableSound();
            } else {
                EnableSound();
            }

        }
        /// <summary>
        /// Plaies the sfx.
        /// </summary>
        /// <param name="clip">Clip.</param>
        public void PlaySfx(AudioClip clip) {
            if (soundOn != 0) {
                //Set the clip of our efxSource audio source to the clip passed in as a parameter.
                efxSource.clip = clip;

                efxSource.volume = efxVolume;

                //Play the clip.
                efxSource.Play();
            }
        }
        /// <summary>
        /// Plaies the sfx.
        /// </summary>
        /// <param name="clip">Clip.</param>
        /// <param name="volume">Volume.</param>
        public void PlaySfx(AudioClip clip, float volume) {
            if (soundOn != 0) {
                //Set the clip of our efxSource audio source to the clip passed in as a parameter.
                efxSource.clip = clip;


                efxSource.volume = volume;

                //Play the clip.
                efxSource.Play();
            }
        }
        /// <summary>
        /// Changes the background music.
        /// </summary>
        /// <param name="clip">Clip.</param>
        public void ChangeBgMusic(AudioClip clip) {
            musicSource.Stop();

            musicSource.clip = clip;

            //Play the clip.
            musicSource.Play();
        }
        /// <summary>
        /// Enables the sound.
        /// </summary>
        public void EnableSound() {
            soundOn = 1;
            efxSource.volume = efxVolume;
            musicSource.volume = musicVolume;
            PlayerManager.GetInstance().UpdateSoundOn(1);
        }
        /// <summary>
        /// Disables the sound.
        /// </summary>
        public void DisableSound() {
            soundOn = 0;
            efxSource.volume = 0f;
            musicSource.volume = 0f;
            PlayerManager.GetInstance().UpdateSoundOn(0);
        }
        /// <summary>
        /// Randomizes the sfx.
        /// </summary>
        /// <param name="clips">Clips.</param>
        public void RandomizeSfx(params AudioClip[] clips) {
            if (soundOn != 0) {
                //Generate a random number between 0 and the length of our array of clips passed in.
                int randomIndex = Random.Range(0, clips.Length);

                //Set the clip to the clip at our randomly chosen index.
                efxSource.clip = clips[randomIndex];

                //Play the clip.
                efxSource.Play();
            }
        }
        /// <summary>
        /// Randomizes the sfx with random pitch.
        /// </summary>
        /// <param name="clips">Clips.</param>
        public void RandomizeSfxWithRandomPitch(params AudioClip[] clips) {
            if (soundOn != 0) {
                //Generate a random number between 0 and the length of our array of clips passed in.
                int randomIndex = Random.Range(0, clips.Length);

                //Choose a random pitch to play back our clip at between our high and low pitch ranges.
                float randomPitch = Random.Range(lowPitchRange, highPitchRange);

                //Set the pitch of the audio source to the randomly chosen pitch.
                efxSource.pitch = randomPitch;

                //Set the clip to the clip at our randomly chosen index.
                efxSource.clip = clips[randomIndex];

                //Play the clip.
                efxSource.Play();
            }
        }
        /// <summary>
        /// Plaies the click sound.
        /// </summary>
        public void PlayClickSound() {
            PlaySfx(clickSound, 1f);
        }
        /// <summary>
        /// Plaies the buy sound.
        /// </summary>
        public void PlayBuySound() {
            PlaySfx(buySound, 1f);
        }
        /// <summary>
        /// Plaies the open menu.
        /// </summary>
        public void PlayOpenMenu() {
            PlaySfx(openMenu, 1f);
        }
        /// <summary>
        /// Plaies the clear campaign.
        /// </summary>
        public void PlayClearCampaign() {
            PlaySfx(clearCampaign, 1f);
        }
        /// <summary>
        /// Plaies the high score.
        /// </summary>
        public void PlayHighScore() {
            PlaySfx(highScore, 1f);
        }
        /// <summary>
        /// Plaies the clip at point.
        /// </summary>
        /// <returns>The clip at point.</returns>
        /// <param name="clip">Clip.</param>
        /// <param name="pos">Position.</param>
        public AudioSource PlayClipAtPoint(AudioClip clip, Vector3 pos) {
            if (soundOn != 0) {
                GameObject tempGO = new GameObject("TempAudio");
                tempGO.transform.position = pos;
                AudioSource aSource = tempGO.AddComponent<AudioSource>();
                aSource.clip = clip;
                aSource.Play();
                Destroy(tempGO, clip.length);
                return aSource;
            }
            return null;
        }
        /// <summary>
        /// Plaies the clip at point.
        /// </summary>
        /// <returns>The clip at point.</returns>
        /// <param name="clip">Clip.</param>
        /// <param name="pos">Position.</param>
        /// <param name="volume">Volume.</param>
        public AudioSource PlayClipAtPoint(AudioClip clip, Vector3 pos, float volume) {
            if (soundOn != 0) {
                GameObject tempGO = new GameObject("TempAudio");
                tempGO.transform.position = pos;
                AudioSource aSource = tempGO.AddComponent<AudioSource>();
                aSource.clip = clip;
                aSource.volume = volume;
                aSource.Play();
                Destroy(tempGO, clip.length);
                return aSource;
            }
            return null;
        }
    }
}