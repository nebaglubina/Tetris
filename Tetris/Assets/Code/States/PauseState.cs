

public class PauseState : IState
{
    private UIManager _uiManager;
    public PauseState(UIManager uiManager)
    {
        _uiManager = uiManager;
    }
    public void OnStateInitialize()
    {
        _uiManager.SetUIMenu(Menus.Pause);
    }

    public void OnStateUpdate()
    {
        
    }

    public void OnStateDispose()
    {
        
    }
}
