using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager 
{

    public void PlayEnemyDeadEffect(GameSignal.EnemyPassedBorderSignal signal) => Debug.Log($"Enemy dead {signal.DeadPosition} coordinate. Play dead effect");
}
