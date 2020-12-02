using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndgameMenu : MenuBase
{
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartGame);
    }

    public void RestartGame()
    {
        EventsObserver.Publish(new IRestartGameEvent());
        EventsObserver.Publish(new IPlaySoundEvent("Newgame"));
    }
}
