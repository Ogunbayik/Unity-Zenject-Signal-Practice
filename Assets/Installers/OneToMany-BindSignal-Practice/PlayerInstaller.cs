using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerDataSO _dataSO;
    public override void InstallBindings()
    {
        Container.BindInstance(_dataSO).AsSingle();

        Container.Bind<PlayerModel>().AsSingle();

        Container.Bind<IPlayerView>().To<PlayerView>().FromComponentInHierarchy().AsSingle();

        Container.BindInterfacesAndSelfTo<PlayerPresenter>().AsSingle().NonLazy();
    }
}