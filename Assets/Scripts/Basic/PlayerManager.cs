using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerManager : MonoBehaviour
{
    private const int _testDamage = 20;

    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus) => _signalBus = signalBus;

    private void Start() => TakeDamage(_testDamage);

    public void TakeDamage(int damageAmount)
    {
        _signalBus.Fire(new GameSignal.PlayerHitSignal(damageAmount)); 
    }
}
