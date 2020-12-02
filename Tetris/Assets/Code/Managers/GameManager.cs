using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : IGameManager
{
    private GameplayState _gameplayState;
    private PauseState _pauseState;
    private LobbyState _lobbyState;
    private EndgameState _endgameState;
    private IState _currentState;
    
    public GameManager(GameplayState gameplayState, PauseState pauseState, LobbyState lobbyState, EndgameState endgameState)
    {
        _gameplayState = gameplayState;
        _pauseState = pauseState;
        _lobbyState = lobbyState;
        _endgameState = endgameState;
    }
    public void Initialize()
    {
        EventsObserver.AddEventListener<IStartGameplayEvent>(StartGameListener);
        EventsObserver.AddEventListener<IPauseEvent>(PauseListener);
        EventsObserver.AddEventListener<IEndGameEvent>(EndGameListener);
        EventsObserver.AddEventListener<IRestartGameEvent>(RestartListener);
        EventsObserver.Publish(new IStartGameplayEvent());
    }

    private void RestartListener(IRestartGameEvent e)
    {
        SetState(_gameplayState);
        EventsObserver.Publish(new ISpawnEvent());
    }

    private void EndGameListener(IEndGameEvent e)
    {
        SetState(_endgameState);
    }

    private void PauseListener(IPauseEvent e)
    {
        if (e.DoPause)
        {
            SetState(_pauseState);
        }
        else
        {
            SetState(_gameplayState);
        }
    }

    private void StartGameListener(IStartGameplayEvent e)
    {
        SetState(_gameplayState);
        EventsObserver.Publish(new ISpawnEvent());
    }

    public void Tick()
    {
        if (_currentState != null)
        {
            _currentState.OnStateUpdate();
        }
    }
    
    public void Dispose()
    {
        EventsObserver.RemoveEventListener<IStartGameplayEvent>(StartGameListener);
        EventsObserver.RemoveEventListener<IPauseEvent>(PauseListener);
        EventsObserver.RemoveEventListener<IEndGameEvent>(EndGameListener);
        EventsObserver.RemoveEventListener<IRestartGameEvent>(RestartListener);
    }


    public void SetState(IState state)
    {
        if (_currentState != null)
        {
            _currentState.OnStateDispose();
        }

        _currentState = state;
        if (_currentState != null)
        {
            _currentState.OnStateInitialize();
            Debug.Log($"Activating state: {state}");
        }
    }

    
}
