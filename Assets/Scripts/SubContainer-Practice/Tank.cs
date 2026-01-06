using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Tank : MonoBehaviour
{
    private TankEngine _engine;
    private TankWeapon _weapon;

    private float _spawnInterval;
    private float _currentTime;

    [Inject]
    public void Construct(TankEngine engine, TankWeapon weapon, float spawnInterval = 0.5f)
    {
        _engine = engine;
        _weapon = weapon;
        _spawnInterval = spawnInterval;
        _currentTime = _spawnInterval;
    }

    private void Start()
    {
        _engine.Move();
        _weapon.Fire();
    }
    private void Update()
    {
        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0)
        {
            _currentTime = _spawnInterval;
            _weapon.Fire();
        }


    }

    public class Factory : PlaceholderFactory<Tank> { }
}
