using UnityEngine;
using Zenject;

public class LocalTankInstaller : MonoInstaller
{
    
    public override void InstallBindings()
    {
        Container.Bind<Tank>().FromComponentOnRoot().AsSingle();
        Container.Bind<TankEngine>().FromComponentOnRoot().AsSingle();
        Container.Bind<TankWeapon>().FromComponentOnRoot().AsSingle();
    }
}