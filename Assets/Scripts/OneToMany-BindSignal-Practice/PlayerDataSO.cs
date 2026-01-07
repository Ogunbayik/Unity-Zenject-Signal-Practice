using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data SO", menuName = "SO/Player Data")]
public class PlayerDataSO : ScriptableObject
{
    [Header("Player Data")]
    [SerializeField] private int _maximumHealth;
    [SerializeField] private float _movementSpeed;

    public int MaximumHealth => _maximumHealth;
    public float MovementSpeed => _movementSpeed;
}
