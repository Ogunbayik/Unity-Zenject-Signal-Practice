using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BulletTrigger : MonoBehaviour
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus) => _signalBus = signalBus;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage();
        }
    }
}
