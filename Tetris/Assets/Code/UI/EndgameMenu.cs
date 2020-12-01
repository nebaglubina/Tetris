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
        Debug.Log("Endgame menu enabled");
        _restartButton.onClick.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(RestartGame);
        Debug.Log("Endgame menu disabled");
    }

    public void RestartGame()
    {
        Managers.GridManager.ClearBoard();
        Managers.ScoreManager.ResetScore();
        //Managers.GameManager.SetState(new GameplayState()); //TODO
    }
}
