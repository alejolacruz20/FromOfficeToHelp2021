using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage;
    public float speed;
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime; //Movimiento de la bala
    }
    private void OnTriggerEnter(Collider target) 
    {
        EnemyHealth damageEnemy = target.gameObject.GetComponent<EnemyHealth>();
        CharacterHealth damagePlayer = target.gameObject.GetComponent<CharacterHealth>();
        if (damageEnemy != null)//Preguntamos si chocamos con el enemigo
        {
            damageEnemy.ColorChangeDamage(damage);
        }
        if (damagePlayer != null)//Preguntamos si chocamos con el player
        {
            damagePlayer.TakeDamage(damage);
        }
        if (target.tag == "Walls" || target.tag == "Enemy" || target.tag == "Player") //Agregamos tambien la pared y lo destruimos
        {
            Destroy(this.gameObject);
        }
    }
}
