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
    
    public void Initialize()
    {
        Debug.Log("Initializing gameplay");
        // if (Managers.GameManager.IsGameActive)
        // {
        //     return;
        // }
        StartGameplay();
    }

    public void Tick()
    {
        _shapeMovement.ShapeUpdate();
    }
    public void Dispose()
    {

    }
    
    private void StartGameplay()
    {
        EventsObserver.Publish(new ISpawnEvent());
        // Managers.GameManager.IsGameActive = true;
        // Managers.UIManager.SetUIMenu(Menus.Gameplay);
    }
}
