using UnityEngine;
using Zenject;

public class MyMonoInstaller : MonoInstaller
{
    [SerializeField] private SpawnManager _spawnManager;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GridManager>().AsSingle().NonLazy();
        Container.Bind<IStateFactory>().To<StateFactory>().AsSingle().WithArguments(Container);
        
        Container.BindInterfacesTo<GameManager>().AsSingle().NonLazy();
        Container.Bind<SpawnManager>().FromInstance(_spawnManager).AsSingle();
        Container.BindInterfacesTo<InputManager>().AsSingle();
        Container.Bind<ScoreManager>().AsSingle();
        Container.Bind<UIManager>().AsSingle();
        Container.Bind<ShapeMovement>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameplayState>().AsSingle();
        Container.Bind<PauseState>().AsSingle();
    }
}