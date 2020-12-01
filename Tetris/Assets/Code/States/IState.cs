
using System;
using UnityEngine;
using Zenject;

public interface IState
{ 
    void Initialize();
    void Tick();
    void Dispose();
}
