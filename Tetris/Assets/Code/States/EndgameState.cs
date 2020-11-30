﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameState : StateBase
{
    public override void Activate()
    {
     Managers.UIManager.SetUIMenu(Menus.Endgame);
     Managers.GameManager.IsGameActive = false;
    }

    public override void Deactivate()
    {
        
    }

    public override void StateUpdate()
    {
        
    }
}
