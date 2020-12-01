using System;

public class RemoveDeferredAction : IDeferredAction
{
    public readonly Action RemoveHandlerAction;

    public RemoveDeferredAction(Action removeHandlerAction)
    {
        RemoveHandlerAction = removeHandlerAction;
    }

    public DeferredActions ActionType()
    {
        return DeferredActions.Remove;
    }
}