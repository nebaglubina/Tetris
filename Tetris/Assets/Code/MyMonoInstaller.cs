using UnityEngine;
using Zenject;

public class MyMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ShapeMovement>().AsTransient();
    }
}