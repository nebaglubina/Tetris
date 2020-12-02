using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IGameManager : IInitializable, ITickable, IDisposable
{
    void SetState(IState state);
}
