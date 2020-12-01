using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager
{
    Shape CurrentShape { get; set; }
    Transform ShapeParent { get; }
    Transform PlannedShape { get; }
    
    void SetState(IState state);
}
