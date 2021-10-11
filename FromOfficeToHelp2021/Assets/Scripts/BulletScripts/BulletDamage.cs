using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage;
    public float speed;
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider target)
    {
        EnemyHealth damageEnemy = target.gameObject.GetComponent<EnemyHealth>();
        CharacterHealth damagePlayer = target.gameObject.GetComponent<CharacterHealth>();
        if (damageEnemy != null)
        {
            damageEnemy.ColorChangeDamage(damage);
        }
        if (damagePlayer != null)
        {
            damagePlayer.TakeDamage(damage);
        }
        if (target.tag == "Walls" || target.tag == "Enemy" || target.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
