using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : IState
{
    public void OnStateInitialize()
    {
        Debug.Log("Initializing pausestate");
    }

    public void OnStateUpdate()
    {
        
    }

    public void OnStateDispose()
    {
        
    }
}
