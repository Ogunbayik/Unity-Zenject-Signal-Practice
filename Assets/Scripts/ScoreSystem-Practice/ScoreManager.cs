using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager 
{
    private int _totalScore;

    public void AddScore(GameSignal.EnemyDeadSignal signal)
    {
        if (signal.Type == EnemyTest.EnemyType.Boss)
            _totalScore += signal.Score * 2;
        else if (signal.Type == EnemyTest.EnemyType.Minion)
            _totalScore += signal.Score;


        Debug.Log($"{signal.Type} type of enemy is dead. New Score: {_totalScore}");
    }
}
