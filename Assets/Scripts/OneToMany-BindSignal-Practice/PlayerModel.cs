using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel 
{
    private PlayerDataSO _data;

    private float _movementSpeed;
    private int _currentHealth;

    public event Action OnPlayerDead;
    public event Action<int> OnPlayerHealthChanged;
    public PlayerModel(PlayerDataSO data)
    {
        _data = data;
        _movementSpeed = data.MovementSpeed;
        _currentHealth = data.MaximumHealth;
    }
    public void Heal(int amount)
    {
        _currentHealth += amount;

        if (_currentHealth > _data.MaximumHealth)
            _currentHealth = _data.MaximumHealth;

        OnPlayerHealthChanged?.Invoke(_currentHealth);
    }
    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;

        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnPlayerDead?.Invoke();
        }

        OnPlayerHealthChanged?.Invoke(_currentHealth);
    }
    public int CurrentHealth => _currentHealth;
    public PlayerDataSO Data => _data;
}
