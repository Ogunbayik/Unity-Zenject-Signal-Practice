using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TankWeapon : MonoBehaviour
{
    private SignalBus _signalBus;
    private Bullet.Pool _bulletPool;

    [SerializeField] private Transform _attackPosition;

    [Inject]
    public void Construct(SignalBus signalBus, Bullet.Pool pool)
    {
        _signalBus = signalBus;
        _bulletPool = pool;
    }
    public void Fire()
    {
        _bulletPool.Spawn(_attackPosition.position, _bulletPool);
        _signalBus.Fire(new GameSignal.TankFireSignal());
    }
}
