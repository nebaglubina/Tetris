
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameplayMenu : MenuBase
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _linesText;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _unpauseButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameObject _pausePanel;


    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(SetPause);
        _unpauseButton.onClick.AddListener(SetUnpause);
        _restartButton.onClick.AddListener(Restart);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(SetPause);
        _unpauseButton.onClick.AddListener(SetUnpause);
        _restartButton.onClick.RemoveListener(Restart);
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
        EventsObserver.Publish(new IPauseEvent(true));
        _pausePanel.SetActive(true);
    }

    public void SetUnpause()
    {
        EventsObserver.Publish(new IPauseEvent(false));
        _pausePanel.SetActive(false);
    }

    public void Restart()
    {
        EventsObserver.Publish(new IRestartGameEvent());
    }
}
