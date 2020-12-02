using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayState : IState
{
    private ShapeMovement _shapeMovement;
    
    public GameplayState(ShapeMovement shapeMovement)
    {
        _shapeMovement = shapeMovement;
    }
    
    public void OnStateInitialize()
    {
        Debug.Log("Initializing gameplay");
    }

    public void OnStateUpdate()
    {
        _shapeMovement.ShapeUpdate();
    }
    public void OnStateDispose()
    {

    }
}
