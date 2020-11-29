
using UnityEngine;

public abstract class StateBase : MonoBehaviour
{
    public abstract void Activate();
    public abstract void Deactivate();
    public abstract void StateUpdate();

    public override string ToString()
    {
        return this.GetType().ToString();
    }
}
