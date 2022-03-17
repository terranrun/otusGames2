using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private List<DataSound> dataSounds = new List<DataSound>();
    private AudioSource audioSource; 
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

   public void PlaySoundEffect(string clipName)
    {
        var audioClip = GetAudioClip(clipName);
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private AudioClip GetAudioClip(string clipName)
    {
        AudioClip clip = null;
        foreach(var sound in dataSounds)
        {
            if (sound.name == clipName)
                clip = sound.audioClip;
        }
        return clip;
    }
    [Serializable]
    private class DataSound
    {
        public string name;
        public AudioClip audioClip;
    }
}
