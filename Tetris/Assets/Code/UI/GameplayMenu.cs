using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayMenu : MenuBase
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _linesText;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _unpauseButton;
    [SerializeField] private GameObject _pausePanel;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(SetPause);
        _unpauseButton.onClick.AddListener(SetUnpause);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(SetPause);
        _unpauseButton.onClick.AddListener(SetUnpause);
    }

    public TextMeshProUGUI ScoreText
    {
        get => _scoreText;
        set => _scoreText = value;
    }

    public TextMeshProUGUI LinesText
    {
        get => _linesText;
        set => _linesText = value;
    }

    public void SetPause()
    {
        Managers.GameManager.SetState(typeof(PauseState));
        _pausePanel.SetActive(true);
    }

    public void SetUnpause()
    {
        Managers.GameManager.SetState(typeof(GameplayState));
        _pausePanel.SetActive(false);
    }
}
