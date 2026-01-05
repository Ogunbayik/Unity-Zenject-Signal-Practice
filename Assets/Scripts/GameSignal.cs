using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSignal
{
    public class PlayerHitSignal
    {
        public int DamageAmount { get; }
        public PlayerHitSignal(int damageAmount) => DamageAmount = damageAmount;
    }
        
        
}
