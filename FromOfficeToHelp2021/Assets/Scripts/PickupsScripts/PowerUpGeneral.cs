using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Creador: Tiago Zedde
public class PowerUpGeneral : MonoBehaviour
{
    public CharacterHealth life;
    public int healingAmount;
    public GameObject target;


    private void OnTriggerEnter(Collider target)
    {
        HealthUp();
        Destroy(gameObject);
    }

    private void Start()
    {
        CharacterHealth healthbar = target.GetComponent<CharacterHealth>();
        life = healthbar;
    }
    public void HealthUp()
    {
        life.SendMessage("Heal", healingAmount);
    }

    //public void HealthUp()
    //{
    //    CharacterHealth life = gameObject.GetComponent<CharacterHealth>();
    //    //healingAmount = amount;
    //    life.Heal(healingAmount);
    //}
}
