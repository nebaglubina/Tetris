using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayState : IState
{
    private ShapeMovement _shapeMovement;
    private SpawnManager _spawnManager;
    public GameplayState(ShapeMovement shapeMovement, SpawnManager spawnManager)
    {
        _shapeMovement = shapeMovement;
        _spawnManager = spawnManager;
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
        _spawnManager.Spawn();
        // Managers.GameManager.IsGameActive = true;
        // Managers.UIManager.SetUIMenu(Menus.Gameplay);
    }
}
