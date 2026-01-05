using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : ITickable
{
    private Enemy.Factory _enemyFactory;

    private float _maxSpawnTimer;
    private float _spawnTimer;

    public EnemySpawner(Enemy.Factory factory ,float maxSpawnTimer = GameConstant.EnemyData.SPAWN_INTERVAL_TIME)
    {
        _enemyFactory = factory;
        _maxSpawnTimer = maxSpawnTimer;
        _spawnTimer = _maxSpawnTimer;
    }
    public void Tick()
    {
        _spawnTimer -= Time.deltaTime;

        if(_spawnTimer <= 0)
        {
            _spawnTimer = _maxSpawnTimer;
            _enemyFactory.Create(GetRandomSpeed(),GetRandomPosition());
        }
    }
    private float GetRandomSpeed()
    {
        var randomSpeed = Random.Range(GameConstant.EnemyData.MINIMIM_MOVEMENT_SPEED, GameConstant.EnemyData.MAXIMUM_MOVEMENT_SPEED);
        return randomSpeed;
    }
    private Vector3 GetRandomPosition()
    {
        var randomX = Random.Range(-GameConstant.EnemyData.SPAWN_BORDER_X_RANGE, GameConstant.EnemyData.SPAWN_BORDER_X_RANGE);
        var randomPos = new Vector3(randomX, 0f, 0f);

        return randomPos;
    }
}
