using UnityEngine;
using Zenject;

public class SpawnInstaller : MonoInstaller
{
    [SerializeField] private GameObject _enemyPrefab;
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<GameSignal.EnemyPassedBorderSignal>();

        Container.Bind<VFXManager>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle().NonLazy();

        Container.BindFactory<float, Vector3, Enemy, Enemy.Factory>()
            .FromComponentInNewPrefab(_enemyPrefab)
            .AsTransient();

        Container.BindSignal<GameSignal.EnemyPassedBorderSignal>()
            .ToMethod<VFXManager>(x => x.PlayEnemyDeadEffect)
            .FromResolve();
    }
}