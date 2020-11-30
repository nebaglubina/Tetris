
using UnityEngine;

[RequireComponent(typeof(GameManager))]
[RequireComponent(typeof(UIManager))]
[RequireComponent(typeof(AudioManager))]
[RequireComponent(typeof(ScoreManager))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(GridManager))]
[RequireComponent(typeof(SpawnManager))]
public class Managers : MonoBehaviour
{
    private static GameManager _gameManager;
    private static UIManager _uiManager;
    private static AudioManager _audioManager;
    private static ScoreManager _scoreManager;
    private static InputManager _inputManager;
    private static GridManager _gridManager;
    private static SpawnManager _spawnManager;

    public static GameManager GameManager => _gameManager;
    public static UIManager UIManager => _uiManager;
    public static AudioManager AudioManager => _audioManager;
    public static ScoreManager ScoreManager => _scoreManager;
    public static InputManager InputManager => _inputManager;
    public static GridManager GridManager => _gridManager;
    public static SpawnManager SpawnManager => _spawnManager;

    private void Awake()
    {
        _gameManager = GetComponent<GameManager>();
        _uiManager = GetComponent<UIManager>();
        _audioManager = GetComponent<AudioManager>();
        _scoreManager = GetComponent<ScoreManager>();
        _inputManager = GetComponent<InputManager>();
        _gridManager = GetComponent<GridManager>();
        _spawnManager = GetComponent<SpawnManager>();
    }
}
