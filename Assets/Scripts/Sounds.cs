using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Sounds
    {
        private AudioSource source;

        public string soundName;
        public AudioClip clip;

        public void SetSource(AudioSource _source)
        {
            source = _source;
            source.clip = clip;
            source.volume = 0.1F;
        }

        public void Play()
        {
            source.Play();
        }

        public void PlayRandomSound(Sounds[] sounds)
        {
            var rand = UnityEngine.Random.Range(0, sounds.Length - 1);
            sounds[rand].Play();
        }

        public void LoadSounds(Sounds[] sounds)
        {
            for (int i = 0; i < sounds.Length; i++)
            {
                GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].soundName);
                //_go.transform.SetParent(this.transform);
                sounds[i].SetSource(_go.AddComponent<AudioSource>());

            }
        }

    }



}
