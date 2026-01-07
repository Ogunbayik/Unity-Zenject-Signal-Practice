using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour, IPlayerView
{
    [Header("UI Settings")]
    [SerializeField] private Button _hitButton;
    [SerializeField] private Button _healButton;
    [SerializeField] private Image _healthFillAmount;
    [SerializeField] private Image _faceImage;
    [SerializeField] private List<Sprite> _faceList = new List<Sprite>();
    [SerializeField] private List<Color> _colorList = new List<Color>();

    public event Action OnClickedHitButton;
    public event Action OnClickedHealButton;

    private void Start()
    {
        _hitButton.onClick.AddListener(() => OnClickedHitButton?.Invoke());
        _healButton.onClick.AddListener(() => OnClickedHealButton?.Invoke());
    }
    public void SetFaceImage(Sprite sprite) => _faceImage.sprite = sprite;
    public void UpdateFillAmount(float currentHealth) => _healthFillAmount.fillAmount = currentHealth;
    public void SetFillColor(Color color) => _healthFillAmount.color = color;

    public List<Sprite> FaceList => _faceList;
    public List<Color> ColorList => _colorList;
}
