using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerPresenter : IInitializable, IDisposable
{
    private PlayerModel _model;
    private IPlayerView _view;

    private SignalBus _signalBus;
    public PlayerPresenter(PlayerModel model, IPlayerView view, SignalBus signalBus)
    {
        _model = model;
        _view = view;
        _signalBus = signalBus;
    }
    public void Initialize()
    {
        _view.UpdateFillAmount(_model.CurrentHealth);
        _view.SetFaceImage(_view.FaceList[GameConstant.HealthStateIndex.PRISTINE]);
        _view.SetFillColor(_view.ColorList[GameConstant.HealthStateIndex.PRISTINE]);

        _model.OnPlayerHealthChanged += Model_OnPlayerHealthChanged;
        _model.OnPlayerDead += Model_OnPlayerDead;
        _view.OnClickedHealButton += _view_OnClickedHealButton;
        _view.OnClickedHitButton += _view_OnClickedHitButton;
    }
    public void Dispose()
    {
        _model.OnPlayerHealthChanged -= Model_OnPlayerHealthChanged;
        _model.OnPlayerDead -= Model_OnPlayerDead;
        _view.OnClickedHealButton -= _view_OnClickedHealButton;
        _view.OnClickedHitButton -= _view_OnClickedHitButton;
    }
    private void _view_OnClickedHitButton() => _model.TakeDamage(GameConstant.Test.DAMAGE);
    private void _view_OnClickedHealButton() => _model.Heal(GameConstant.Test.HEAL);
    private void Model_OnPlayerHealthChanged(int currentHealth)
    {
        var healthPercentage = (float)currentHealth / _model.Data.MaximumHealth;

        if (healthPercentage <= 0.25f)
        {
            _view.SetFaceImage(_view.FaceList[GameConstant.HealthStateIndex.CRITICAL]);
            _view.SetFillColor(_view.ColorList[GameConstant.HealthStateIndex.CRITICAL]);
        }
        else if (healthPercentage <= 0.5f)
        {
            _view.SetFaceImage(_view.FaceList[GameConstant.HealthStateIndex.WOUNDED]);
            _view.SetFillColor(_view.ColorList[GameConstant.HealthStateIndex.WOUNDED]);
        }
        else if (healthPercentage <= 0.75f)
        {
            _view.SetFaceImage(_view.FaceList[GameConstant.HealthStateIndex.HEALTHY]);
            _view.SetFillColor(_view.ColorList[GameConstant.HealthStateIndex.HEALTHY]);
        }
        else if (healthPercentage <= 1f)
        {
            _view.SetFaceImage(_view.FaceList[GameConstant.HealthStateIndex.PRISTINE]);
            _view.SetFillColor(_view.ColorList[GameConstant.HealthStateIndex.PRISTINE]);
        }

        _view.UpdateFillAmount(healthPercentage);
    }
    private void Model_OnPlayerDead()
    {
        _view.SetFaceImage(_view.FaceList[GameConstant.HealthStateIndex.DEAD]);
        _signalBus.Fire(new GameSignal.OnLevelFailed());
    }

}
