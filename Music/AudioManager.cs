using System;
using UnityEngine;
using System.Collections;

namespace Utils
{
    public class AudioManager : MonoBehaviour
    {
        Sound[] sounds;
        static AudioManager instance;

        void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);

            sounds = Resources.LoadAll<Sound>("Sounds");
            foreach (Sound sound in sounds)
            {
                AudioSource source = gameObject.AddComponent<AudioSource>();

                source.clip = sound.clip;
                source.volume = sound.volume;
                source.pitch = sound.pitch;
                source.loop = sound.loop;

                sound.source = source;
            }
        }

        void Start() => Play("Theme");

        public static void Play(string name, bool pauseTheme = false)
        {
            Sound s = Array.Find(instance.sounds, sound => sound.name == name);
            if (!s)
            {
                Debug.LogWarning($"Sound {name} not found");
                return;
            }
            if (pauseTheme) Pause("Theme", s.source.clip.length);
            s.source.Play();
        }

        static void Pause(string name, float time)
        {
            Sound s = Array.Find(instance.sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning($"Sound {name} not found");
                return;
            }
            s.source.Pause();
            instance.StartCoroutine(instance.WaitAndUnpause(s.source, time));
        }

        IEnumerator WaitAndUnpause(AudioSource source, float time)
        {
            yield return new WaitForSeconds(time);
            source.UnPause();
        }
    }
}