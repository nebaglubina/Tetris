using UnityEngine;
using Zenject;

public class MyMonoInstaller : MonoInstaller
{
    [SerializeField] private SpawnManager _spawnManager = default;
    [SerializeField] private UIManager _uiManager = default;
    [SerializeField] private AudioManager _audioManager = default;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GridManager>().AsSingle().NonLazy();
        Container.BindInterfacesTo<GameManager>().AsSingle().NonLazy();
        Container.Bind<SpawnManager>().FromInstance(_spawnManager).AsSingle();
        Container.Bind<UIManager>().FromInstance(_uiManager).AsSingle();
        Container.Bind<AudioManager>().FromInstance(_audioManager).AsSingle();
        Container.Bind<ShapeMovement>().AsSingle();
        Container.Bind<GameplayState>().AsSingle();
        Container.Bind<PauseState>().AsSingle();
        Container.Bind<LobbyState>().AsSingle();
        Container.Bind<EndgameState>().AsSingle();
        Container.BindInterfacesTo<ScoreManager>().AsSingle();
        Container.BindInterfacesTo<InputManager>().AsSingle();
    }
}