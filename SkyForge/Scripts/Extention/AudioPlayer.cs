/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEngine;
using System;

namespace SkyForge.Extension
{
    public class AudioPlayer : MonoBehaviour
    {
        public event Action OnStopPlayingClip;
        private AudioSource m_audioSource;

        private void Start()
        {
#if UNITY_EDITOR
            m_audioSource = UnityExtension.AddComponentInEditor<AudioSource>(transform);
#endif
        }

        private void Update()
        {
            if (!m_audioSource.isPlaying)
            {
                OnStopPlayingClip?.Invoke();
            }
        }

        public void PlayClip(AudioClip clip)
        {
            m_audioSource.clip = clip;
            m_audioSource.Play();
        }

        public void StopClip()
        {
            m_audioSource.Stop();
        }
    }
}