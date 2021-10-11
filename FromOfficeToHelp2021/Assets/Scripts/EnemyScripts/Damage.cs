using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider target)
    {
        CharacterHealth damageEnemy = target.gameObject.GetComponent<CharacterHealth>();
        if (damageEnemy != null)
        {
            damageEnemy.TakeDamage(damage);
        }
    }
}
