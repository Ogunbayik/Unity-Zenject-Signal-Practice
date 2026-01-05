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
        public EnemyTest.EnemyType Type;
        public int Score;

        public EnemyDeadSignal(EnemyTest.EnemyType type, int score)
        {
            Type = type; 
            Score = score;
        }
    }

    public class EnemyPassedBorderSignal {
        public Vector3 DeadPosition { get; }

        public EnemyPassedBorderSignal(Vector3 deadPosition)  => DeadPosition = deadPosition;
    
    }

}
