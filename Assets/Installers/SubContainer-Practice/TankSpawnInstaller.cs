using UnityEngine;
using Zenject;

public class TankSpawnInstaller : MonoInstaller
{
    [Header("Prefab Settings")]
    [SerializeField] private GameObject _tankPrefab;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _poolSize;
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().AsSingle();
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<GameSignal.TankFireSignal>();

        Container.BindSignal<GameSignal.TankFireSignal>()
            .ToMethod<GameManager>(x => x.TestDebugger)
            .FromResolve();

        Container.BindInterfacesAndSelfTo<TankSpawnManager>().AsSingle();

        Container.Bind<Bullet>().FromComponentOnRoot().AsSingle();
        Container.Bind<BulletTrigger>().FromComponentOnRoot().AsSingle();

        Container.BindMemoryPool<Bullet, Bullet.Pool>()
            .WithInitialSize(_poolSize)
            .FromComponentInNewPrefab(_bulletPrefab)
            .UnderTransformGroup("Bullets");

        Container.BindFactory<Tank, Tank.Factory>()
            .FromSubContainerResolve()
            .ByNewContextPrefab(_tankPrefab);
    }
}