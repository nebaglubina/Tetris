using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private GameData _gameData = default;
    private AudioSource _audioSource = default;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        EventsObserver.AddEventListener<IPlaySoundEvent>(Play);
    }

    private void OnDisable()
    {
        EventsObserver.AddEventListener<IPlaySoundEvent>(Play);
    }

    public void Play(IPlaySoundEvent e)
    {
        AudioClip sound = Array.Find(_gameData.Clips, s => s.name == e.Name);
        if (sound != null)
        {
          _audioSource.PlayOneShot(sound);
        }
    }
    
}
