using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayState : IState
{
    private ShapeMovement _shapeMovement;
    private UIManager _uiManager;
    
    public GameplayState(ShapeMovement shapeMovement, UIManager uiManager)
    {
        _shapeMovement = shapeMovement;
        _uiManager = uiManager;
    }
    
    public void OnStateInitialize()
    {
        _uiManager.SetUIMenu(Menus.Gameplay);
    }

    public void OnStateUpdate()
    {
        _shapeMovement.ShapeUpdate();
    }
    public void OnStateDispose()
    {

    }
}
