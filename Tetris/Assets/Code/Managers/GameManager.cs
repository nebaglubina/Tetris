using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : IGameManager
{
    private bool _isGameActive = false;
    [Inject]
    private IState _currentState;


    
    public IState CurrentState => _currentState;

    public bool IsGameActive
    {
        get => _isGameActive;
        set => _isGameActive = value;
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

    public void Initialize()
    {
        SetState(_currentState);
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
        
    }
}
