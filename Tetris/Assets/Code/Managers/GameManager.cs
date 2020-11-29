using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform _blockHolder;
    [SerializeField] private Transform _plannedShape;
    
    private bool _isGameActive;
    private Shape _currentShape;
    private StateBase _currentState;

    public Transform BlockHolder => _blockHolder;
    public StateBase CurrentState => _currentState;
    public Transform PlannedShape => _plannedShape;

    public bool IsGameActive
    {
        get => _isGameActive;
        set => _isGameActive = value;
    }

    public Shape CurrentShape
    {
        get => _currentShape;
        set => _currentShape = value;
    }

    private void Awake()
    {
        _isGameActive = false;
    }

    private void Start()
    {
        SetState(typeof(GameplayState));
    }

    public void SetState(System.Type state)
    {
        if (_currentState != null)
        {
            _currentState.Deactivate();
        }
        _currentState = GetComponentInChildren(state) as StateBase;
        if (_currentState != null)
        {
            _currentState.Activate();
        }
    }

    private void Update()
    {
        if (_currentState != null)
        {
            _currentState.StateUpdate();
        }
    }
}
