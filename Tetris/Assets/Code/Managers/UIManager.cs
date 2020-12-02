using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Menus
{
    Lobby,
    Gameplay,
    Endgame
}
public class UIManager : MonoBehaviour
{
    [SerializeField] private LobbyMenu _lobbyMenu;
    [SerializeField] private GameplayMenu _gameplayMenu;
    [SerializeField] private EndgameMenu _endgameMenu;



    public void SetUIMenu(Menus menu)
    {
        switch (menu)
        {
            case Menus.Lobby:
                SetLobbyMenu();
                break;
            case Menus.Gameplay:
                SetGameplayMenu();
                break;
            case Menus.Endgame:
                SetEndgameMenu();
                break;
        }
    }

    public void UpdateUIScore(int scoreValue, int lines)
    {
        _gameplayMenu.ScoreText.SetText(scoreValue.ToString());
        _gameplayMenu.LinesText.SetText(lines.ToString());
    }

    private void SetLobbyMenu()
    {
        _gameplayMenu.gameObject.SetActive(false);
        _endgameMenu.gameObject.SetActive(false);
        _lobbyMenu.gameObject.SetActive(true);
    }

    private void SetGameplayMenu()
    {
        
        _gameplayMenu.gameObject.SetActive(true);
        _endgameMenu.gameObject.SetActive(false);
        _lobbyMenu.gameObject.SetActive(false);
    }

    private void SetEndgameMenu()
    {
        Debug.Log("EndGameMenu setting");
        _gameplayMenu.gameObject.SetActive(false);
        _endgameMenu.gameObject.SetActive(true);
        _lobbyMenu.gameObject.SetActive(false);
    }
}
