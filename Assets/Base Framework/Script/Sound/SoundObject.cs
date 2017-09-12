using UnityEngine;
using System.Collections;

namespace BaseFramework {
    /// <summary>
    /// Sound object.
    /// </summary>
    public class SoundObject : MonoBehaviour {
        /// <summary>
        /// The object audio.
        /// </summary>
        public AudioSource objectAudio;
        /// <summary>
        /// Awake this instance.
        /// </summary>
        void Awake() {
            gameObject.AddComponent<AudioSource>();
            objectAudio = GetComponent<AudioSource>();
            objectAudio.playOnAwake = false;
        }
        /// <summary>
        /// Update this instance.
        /// </summary>
        void Update() {

        }
        /// <summary>
        /// Plaies the sfx.
        /// </summary>
        /// <param name="clip">Clip.</param>
        public void PlaySfx(AudioClip clip) {
            if (PlayerManager.GetInstance().soundOn != 0) {
                //Set the clip of our efxSource audio source to the clip passed in as a parameter.
                objectAudio.clip = clip;
                objectAudio.loop = false;
                objectAudio.volume = 1.0f;
                //Play the clip.
                objectAudio.Play();
            }
        }
        /// <summary>
        /// Plaies the sfx.
        /// </summary>
        /// <param name="clip">Clip.</param>
        /// <param name="volume">Volume.</param>
        public void PlaySfx(AudioClip clip, float volume) {
            if (PlayerManager.GetInstance().soundOn != 0) {
                //Set the clip of our efxSource audio source to the clip passed in as a parameter.
                objectAudio.clip = clip;
                objectAudio.loop = false;
                objectAudio.volume = volume;
                //Play the clip.
                objectAudio.Play();
            }
        }
        /// <summary>
        /// Plaies the sfx loop.
        /// </summary>
        /// <param name="clip">Clip.</param>
        public void PlaySfxLoop(AudioClip clip) {
            if (PlayerManager.GetInstance().soundOn != 0) {
                //Set the clip of our efxSource audio source to the clip passed in as a parameter.
                objectAudio.clip = clip;
                objectAudio.loop = true;
                objectAudio.volume = 1.0f;
                //Play the clip.
                objectAudio.Play();
            }
        }
        /// <summary>
        /// Plaies the sfx loop.
        /// </summary>
        /// <param name="clip">Clip.</param>
        /// <param name="volume">Volume.</param>
        public void PlaySfxLoop(AudioClip clip, float volume) {
            if (PlayerManager.GetInstance().soundOn != 0) {
                //Set the clip of our efxSource audio source to the clip passed in as a parameter.
                objectAudio.clip = clip;
                objectAudio.loop = true;
                objectAudio.volume = volume;
                //Play the clip.
                objectAudio.Play();
            }
        }
        /// <summary>
        /// Randomizes the sfx.
        /// </summary>
        /// <param name="clips">Clips.</param>
        public void RandomizeSfx(params AudioClip[] clips) {
            if (PlayerManager.GetInstance().soundOn != 0) {
                //Generate a random number between 0 and the length of our array of clips passed in.
                int randomIndex = Random.Range(0, clips.Length);
                //Set the clip to the clip at our randomly chosen index.
                objectAudio.clip = clips[randomIndex];
                objectAudio.loop = false;
                objectAudio.volume = 1.0f;
                //Play the clip.
                objectAudio.Play();
            }
        }
        /// <summary>
        /// Randomizes the sfx.
        /// </summary>
        /// <param name="volume">Volume.</param>
        /// <param name="clips">Clips.</param>
        public void RandomizeSfx(float volume, params AudioClip[] clips) {
            if (PlayerManager.GetInstance().soundOn != 0) {
                //Generate a random number between 0 and the length of our array of clips passed in.
                int randomIndex = Random.Range(0, clips.Length);
                //Set the clip to the clip at our randomly chosen index.
                objectAudio.clip = clips[randomIndex];
                objectAudio.loop = false;
                objectAudio.volume = volume;
                //Play the clip.
                objectAudio.Play();
            }
        }
        /// <summary>
        /// Plaies the sequence sound.
        /// </summary>
        /// <returns>The sequence sound.</returns>
        /// <param name="clips">Clips.</param>
        public IEnumerator PlaySequenceSound(params AudioClip[] clips) {
            if (PlayerManager.GetInstance().soundOn != 0) {
                objectAudio.volume = 1.0f;
                for (int i = 0; i < clips.Length; i++) {
                    objectAudio.clip = clips[i];

                    objectAudio.Play();
                    yield return new WaitForSeconds(objectAudio.clip.length);
                }
            }
        }
        /// <summary>
        /// Plaies the sequence sound.
        /// </summary>
        /// <returns>The sequence sound.</returns>
        /// <param name="volume">Volume.</param>
        /// <param name="clips">Clips.</param>
        public IEnumerator PlaySequenceSound(float volume, params AudioClip[] clips) {
            if (PlayerManager.GetInstance().soundOn != 0) {
                objectAudio.volume = volume;
                for (int i = 0; i < clips.Length; i++) {
                    objectAudio.clip = clips[i];
                    objectAudio.Play();
                    yield return new WaitForSeconds(objectAudio.clip.length);
                }
            }
        }
        /// <summary>
        /// Plaies the start and loop.
        /// </summary>
        /// <returns>The start and loop.</returns>
        /// <param name="start">Start.</param>
        /// <param name="loop">Loop.</param>
        public IEnumerator PlayStartAndLoop(AudioClip start, AudioClip loop) {
            if (PlayerManager.GetInstance().soundOn != 0) {
                objectAudio.clip = start;
                objectAudio.loop = false;
                objectAudio.volume = 1.0f;
                objectAudio.Play();
                yield return new WaitForSeconds(objectAudio.clip.length);
                objectAudio.clip = loop;
                objectAudio.loop = true;
                objectAudio.Play();
            }
        }
        /// <summary>
        /// Plaies the start and loop.
        /// </summary>
        /// <returns>The start and loop.</returns>
        /// <param name="start">Start.</param>
        /// <param name="loop">Loop.</param>
        /// <param name="volume">Volume.</param>
        public IEnumerator PlayStartAndLoop(AudioClip start, AudioClip loop, float volume) {
            if (PlayerManager.GetInstance().soundOn != 0) {
                objectAudio.clip = start;
                objectAudio.loop = false;
                objectAudio.volume = volume;
                objectAudio.Play();
                yield return new WaitForSeconds(objectAudio.clip.length);
                objectAudio.clip = loop;
                objectAudio.loop = true;
                objectAudio.Play();
            }
        }
    }
}