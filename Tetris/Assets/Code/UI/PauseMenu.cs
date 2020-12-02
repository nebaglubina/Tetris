
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MenuBase
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _unpauseButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(Restart);
        _unpauseButton.onClick.AddListener(Unpause);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(Restart);
        _unpauseButton.onClick.AddListener(Unpause);
    }

    private void Restart()
    {
        EventsObserver.Publish(new IRestartGameEvent());
        EventsObserver.Publish(new IPlaySoundEvent("Newgame"));
    }

    private void Unpause()
    {
        EventsObserver.Publish(new IPauseEvent(false));
        EventsObserver.Publish(new IPlaySoundEvent("Resume"));
    }
}
