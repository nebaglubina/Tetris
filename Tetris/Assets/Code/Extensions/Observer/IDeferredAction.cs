    public interface IDeferredAction
    { 
        DeferredActions ActionType();
    }

    public enum DeferredActions
    {
        Remove,
        Publish
    }
   
