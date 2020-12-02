using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IGameManager : IInitializable, ITickable
{
    void SetState(IState state);
}
