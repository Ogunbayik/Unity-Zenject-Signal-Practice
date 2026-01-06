using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TankSpawnManager : IInitializable
{
    private Tank.Factory _tankFactory;
    public TankSpawnManager(Tank.Factory factory)
    {
        _tankFactory = factory;
    }
    public void Initialize()
    {
        var tank = _tankFactory.Create();
        Debug.Log("Created");
    }

}
