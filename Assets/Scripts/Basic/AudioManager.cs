using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public void PlayHitSound(GameSignal.PlayerHitSignal signal)
    {
        Debug.Log($"Audio: Play hit sound! Damage {signal.DamageAmount}");
    }
}
