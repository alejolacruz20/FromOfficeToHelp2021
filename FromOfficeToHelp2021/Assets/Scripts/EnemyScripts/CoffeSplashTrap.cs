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
        CharacterHealth damageEnemy = target.gameObject.GetComponent<CharacterHealth>(); //Pedimos el gameObject del Player
        if (damageEnemy != null)
        {
            damageEnemy.TakeDamage(damage); //Hacemos daño
        }
    }

    private void OnTriggerStay(Collider target)
    {
        CharacterHealth damageEnemy = target.gameObject.GetComponent<CharacterHealth>();
        if (damageEnemy != null) //Pedimos si el gameObject no es null y hacemos daño por segundo
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
