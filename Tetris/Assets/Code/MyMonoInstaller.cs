using UnityEngine;
using Zenject;

public class MyMonoInstaller : MonoInstaller
{
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private AudioManager _audioManager;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GridManager>().AsSingle().NonLazy();
        //Container.Bind<IStateFactory>().To<StateFactory>().AsSingle().WithArguments(Container); //todo delete
        
        Container.BindInterfacesTo<GameManager>().AsSingle().NonLazy();
        Container.Bind<SpawnManager>().FromInstance(_spawnManager).AsSingle();
        Container.Bind<UIManager>().FromInstance(_uiManager).AsSingle();
        Container.Bind<AudioManager>().FromInstance(_audioManager).AsSingle();
        Container.Bind<ShapeMovement>().AsSingle();
        Container.Bind<GameplayState>().AsSingle();
        Container.Bind<PauseState>().AsSingle();
        Container.Bind<LobbyState>().AsSingle();
        Container.Bind<EndgameState>().AsSingle();
        Container.Bind<ScoreManager>().AsSingle();
        Container.BindInterfacesTo<InputManager>().AsSingle();
    }
}