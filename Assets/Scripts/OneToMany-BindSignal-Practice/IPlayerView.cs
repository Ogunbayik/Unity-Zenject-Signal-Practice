using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerView 
{
    public event Action OnClickedHitButton;
    public event Action OnClickedHealButton;
    void SetFaceImage(Sprite sprite);
    void UpdateFillAmount(float currentHealth);
    void SetFillColor(Color color);
    List<Sprite> FaceList {  get; }
    List<Color> ColorList {  get; }
}
