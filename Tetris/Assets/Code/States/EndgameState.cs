using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameState : IState
{
    public void OnStateInitialize()
    {
        Debug.Log("Initializing endgame");
        Managers.UIManager.SetUIMenu(Menus.Endgame);
        Managers.GameManager.IsGameActive = false;
    }

    public void OnStateUpdate()
    {
        
    }

    public void OnStateDispose()
    {
        
    }
}
