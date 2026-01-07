using UnityEngine;
using Zenject;

public class SignalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        //Signals
        Container.DeclareSignal<GameSignal.OnLevelFailed>();
        Container.DeclareSignal<GameSignal.OnLevelRestart>();

        Container.Bind<GameUIManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<AudioSystem>().AsSingle();
        Container.Bind<InputManager>().AsSingle();

        //GameOver
        Container.BindSignal<GameSignal.OnLevelFailed>()
            .ToMethod<GameUIManager>(x => x.ToggleGameOverUI)
            .FromResolve();
        Container.BindSignal<GameSignal.OnLevelFailed>()
            .ToMethod<AudioSystem>(x => x.PlayGameOverMusic)
            .FromResolve();
        Container.BindSignal<GameSignal.OnLevelFailed>()
            .ToMethod<InputManager>(x => x.InputDisable)
            .FromResolve();

        //Restart
        Container.BindSignal<GameSignal.OnLevelRestart>()
            .ToMethod<GameUIManager>(x => x.HideGameOverUI)
            .FromResolve();
        Container.BindSignal<GameSignal.OnLevelRestart>()
            .ToMethod<AudioSystem>(x => x.PlayGameMusic)
            .FromResolve();
        Container.BindSignal<GameSignal.OnLevelRestart>()
            .ToMethod<InputManager>(x => x.InputEnable)
            .FromResolve();
    }
}