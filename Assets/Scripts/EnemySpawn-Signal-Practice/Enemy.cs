using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    private SignalBus _signalBus;

    private float _movementSpeed;
    private Vector3 _spawnPosition;

    [Inject]
    public void Construct(SignalBus signalBus,float movementSpeed, Vector3 spawnPosition)
    {
        _signalBus = signalBus;
        _movementSpeed = movementSpeed;
        _spawnPosition = spawnPosition;

        transform.position = _spawnPosition;
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime);

        if(transform.position.z > 10f)
        {
            _signalBus.Fire(new GameSignal.EnemyPassedBorderSignal(transform.position));
            Destroy(gameObject);
        }
    }

    public class Factory : PlaceholderFactory<float, Vector3, Enemy> { }
}
