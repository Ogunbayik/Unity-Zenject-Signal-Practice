using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyTest : MonoBehaviour
{
    private SignalBus _signalBus;

    public enum EnemyType { Minion, Boss };

    [Header("Enemy Settings")]
    [SerializeField] private EnemyType _type;
    [SerializeField] private int _health;
    [SerializeField] private int _score;

    [Inject]
    public void Contsruct(SignalBus signalBus) => _signalBus = signalBus;

    private void OnMouseDown() => TakeDamage(GameConstant.Damage.TEST_DAMAGE);
    public void TakeDamage(int damageAmount)
    {
        _health -= damageAmount;

        if (_health <= 0)
        {
            _signalBus.Fire(new GameSignal.EnemyDeadSignal(_type, _score));
            Destroy(gameObject);
        }
    }
}
