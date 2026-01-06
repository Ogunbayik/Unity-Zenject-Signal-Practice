using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour, IPoolable<Vector3, IMemoryPool>
{
    private IMemoryPool _pool;

    private float _bulletSpeed;
    private float _lifeTime;

    public void OnSpawned(Vector3 spawnPos, IMemoryPool pool)
    {
        _pool = pool;
        transform.position = spawnPos;

        _bulletSpeed = GetRandomSpeed();
        _lifeTime = GetRandomLifetime();
    }
    public void OnDespawned()
    {
        _pool = null;
    }
    public void ReturnToPool()
    {
        _pool.Despawn(this);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * _bulletSpeed * Time.deltaTime);

        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
            ReturnToPool();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage();
            ReturnToPool();
        }
    }
    private float GetRandomLifetime() => Random.Range(GameConstant.TankData.MINIMUM_LIFETIME, GameConstant.TankData.MAXIMUM_LIFETME);
    private float GetRandomSpeed() => Random.Range(GameConstant.TankData.MINIMUM_BULLET_SPEED, GameConstant.TankData.MAXIMUM_BULLET_SPEED);
    public class Pool : MonoPoolableMemoryPool<Vector3, IMemoryPool, Bullet> { }
}
