using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IDamageable
{
    public void TakeDamage()
    {
        Debug.Log("Hitted" + gameObject.name);
    }

}
