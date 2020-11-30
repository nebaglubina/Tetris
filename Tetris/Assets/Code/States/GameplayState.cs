﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayState : StateBase
{
    
    public override void Activate()
    {
        if (Managers.GameManager.IsGameActive)
        {
            return;
        }
        StartGameplay();
    }

    public override void Deactivate()
    {

    }

    public override void StateUpdate()
    {
        if (Managers.GameManager.CurrentShape != null)
        {
            Managers.GameManager.CurrentShape.ShapeMovement.ShapeUpdate();
        }
    }

    private void StartGameplay()
    {
        Managers.SpawnManager.Spawn();
        Managers.GameManager.IsGameActive = true;
        Managers.UIManager.SetUIMenu(Menus.Gameplay);
    }
}
