using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameState : IState
{
    public void Initialize()
    {
        Debug.Log("Initializing endgame");
        Managers.UIManager.SetUIMenu(Menus.Endgame);
        Managers.GameManager.IsGameActive = false;
    }

    public void Tick()
    {
        
    }

    public void Dispose()
    {
        
    }
}
