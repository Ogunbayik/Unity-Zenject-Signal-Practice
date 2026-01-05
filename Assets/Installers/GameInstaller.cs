using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<GameSignal.PlayerHitSignal>();

        Container.Bind<AudioManager>().FromComponentInHierarchy().AsSingle();

        Container.BindSignal<GameSignal.PlayerHitSignal>()
            .ToMethod<AudioManager>(x => x.PlayHitSound)
            .FromResolve();

    }
}