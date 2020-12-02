using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameState : IState
{
    private UIManager _uiManager;
    public EndgameState(UIManager uiManager)
    {
        _uiManager = uiManager;
    }
    
    public void OnStateInitialize()
    {
        _uiManager.SetUIMenu(Menus.Endgame);
    }

    public void OnStateUpdate()
    {
        
    }

    public void OnStateDispose()
    {
        
    }
}
