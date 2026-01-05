using UnityEngine;
using Zenject;

public class ScoreInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ScoreManager>().AsSingle().NonLazy();

        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<GameSignal.EnemyDeadSignal>();

        Container.BindSignal<GameSignal.EnemyDeadSignal>()
            .ToMethod<ScoreManager>(x => x.AddScore)
            .FromResolve();

    }
}