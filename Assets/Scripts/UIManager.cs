using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIManager : MonoBehaviour
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus) => _signalBus = signalBus;

    private void OnEnable() => _signalBus.Subscribe<GameSignal.PlayerHitSignal>(DamageDebugger);
    private void OnDisable() => _signalBus.Unsubscribe<GameSignal.PlayerHitSignal>(DamageDebugger);
    public void DamageDebugger(GameSignal.PlayerHitSignal signal) => Debug.Log($"Player is taken {signal.DamageAmount} damage");
}
