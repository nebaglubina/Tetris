using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour, IGameManager
{
    private bool _isGameActive;
    [Inject]
    private IState _currentState;
    //private GameplayState _gameplayState;

    
    public IState CurrentState => _currentState;

    public bool IsGameActive
    {
        get => _isGameActive;
        set => _isGameActive = value;
    }

    private void Awake()
    {
        _isGameActive = false;
    }

    // [Inject]
    // private void Construct(GameplayState gameplayState)
    // {
    //     
    // }

    private void Start()
    {
        SetState(_currentState);
    }

    public void SetState(IState state)
    {
        if (_currentState != null)
        {
            _currentState.Dispose();
        }

        _currentState = state;
        if (_currentState != null)
        {
            _currentState.Initialize();
            Debug.Log($"Activating state: {state}");
        }
    }

    private void Update()
    {
        if (_currentState != null)
        {
            _currentState.Tick();
        }
    }
}
