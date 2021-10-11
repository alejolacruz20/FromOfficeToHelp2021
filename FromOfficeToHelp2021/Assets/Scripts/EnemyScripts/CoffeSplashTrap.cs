using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creador: Gabriel Ceriani
public class CoffeSplashTrap : MonoBehaviour
{
    public int damage;
    public float chronometer;

    private void OnTriggerEnter(Collider target)
    {
        CharacterHealth damageEnemy = target.gameObject.GetComponent<CharacterHealth>();
        if (damageEnemy != null)
        {
            damageEnemy.TakeDamage(damage);
        }
    }

    private void OnTriggerStay(Collider target)
    {
        CharacterHealth damageEnemy = target.gameObject.GetComponent<CharacterHealth>();
        if (damageEnemy != null)
        {
            chronometer += 1 * Time.deltaTime;
            if (chronometer >= 2)
            {
                damageEnemy.TakeDamage(damage);
                Debug.Log(damage + " de daño");
                chronometer = 0;
            }
        }
    }
}
