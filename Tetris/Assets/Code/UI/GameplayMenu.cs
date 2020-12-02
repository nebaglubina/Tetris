
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameplayMenu : MenuBase
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _linesText;
    [SerializeField] private Button _pauseButton;


    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(SetPause);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(SetPause);
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
        EventsObserver.Publish(new IPlaySoundEvent("Pause"));
    }
}
