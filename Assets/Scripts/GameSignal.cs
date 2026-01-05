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
        
        
    public class EnemyDeadSignal
    {
        public Enemy.EnemyType Type;
        public int Score;

        public EnemyDeadSignal(Enemy.EnemyType type, int score)
        {
            Type = type; 
            Score = score;
        }
    }
}
