using System;
using UnityEngine;
using UnityEngine.UI;

public class LobbyMenu : MenuBase
{
    [SerializeField] private Button _startButton;

    private void Start()
    {
        EventsObserver.Publish(new IPlaySoundEvent("Background"));
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartGame);
    }
    
    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(StartGame);
    }
    private void StartGame()
    {
        EventsObserver.Publish(new IStartGameplayEvent());
        EventsObserver.Publish(new IPlaySoundEvent("Newgame"));
    }
}
