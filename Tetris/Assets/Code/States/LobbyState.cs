
public class LobbyState : IState
{
    private UIManager _uiManager;
    public LobbyState(UIManager uiManager)
    {
        _uiManager = uiManager;
    }
    public void OnStateInitialize()
    {
        _uiManager.SetUIMenu(Menus.Lobby);
    }

    public void OnStateUpdate()
    {
        
    }

    public void OnStateDispose()
    {
        
    }
}
