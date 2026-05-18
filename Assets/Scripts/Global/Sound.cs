using UnityEngine;

namespace Global
{
    public class Sound : MonoBehaviour
    {
        private AudioSource bgAudio;
        private AudioSource shotAudio;
        private string resourcesPath = "";

        private void Awake()
        {
            bgAudio = gameObject.AddComponent<AudioSource>();
            shotAudio = gameObject.AddComponent<AudioSource>();
            bgAudio.volume = 0.88f;
            bgAudio.loop = true;
            bgAudio.playOnAwake = true;
            shotAudio.volume = 0.94f;
        }

        public void PlayBackgroundAudio(string audioName)
        {
            string path = resourcesPath + "/" + audioName;
            AudioClip clip = Resources.Load<AudioClip>(path);
            if (clip != bgAudio.clip && clip != null)
            {
                bgAudio.clip = clip;
                bgAudio.Play();
            }
        }

        public void PlayEffectAudio(string audioName)
        {
            string path = resourcesPath + "/" + audioName;
            AudioClip clip = Resources.Load<AudioClip>(path);
            if (clip != null)
            {
                shotAudio.PlayOneShot(clip);
            }
        }
    }
}