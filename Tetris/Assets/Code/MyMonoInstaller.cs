using UnityEngine;
using Zenject;

public class MyMonoInstaller : MonoInstaller
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private GridManager _gridManager;
    public override void InstallBindings()
    {
        Container.Bind<IStateFactory>().To<StateFactory>().AsSingle().WithArguments(Container);
        
        Container.BindInterfacesTo<GameManager>().FromInstance(_gameManager).AsSingle().NonLazy();
        Container.Bind<SpawnManager>().FromInstance(_spawnManager).AsSingle();
        Container.BindInterfacesTo<InputManager>().AsSingle();
        Container.Bind<GridManager>().FromInstance(_gridManager).AsSingle();
        Container.Bind<ScoreManager>().AsSingle();
        Container.Bind<UIManager>().AsSingle();
        Container.Bind<ShapeMovement>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameplayState>().AsSingle();
        Container.Bind<PauseState>().AsSingle();
    }
}