
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
    [SerializeField] private GameObject _pausePanel;
    private IStateFactory _stateFactory;
    private IGameManager _gameManager;

    [Inject]
    private void Construct(IStateFactory stateFactory, IGameManager gameManager)
    {
        _stateFactory = stateFactory;
        _gameManager = gameManager;
    }

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
        //Managers.GameManager.SetState(new PauseState());//Todo
        var state = _stateFactory.Create<PauseState>();
        _gameManager.SetState(state);
        _pausePanel.SetActive(true);
    }

    public void SetUnpause()
    {
        //Managers.GameManager.SetState(new GameplayState());//todo
        var state = _stateFactory.Create<GameplayState>();
        _gameManager.SetState(state);
        _pausePanel.SetActive(false);
    }
}
