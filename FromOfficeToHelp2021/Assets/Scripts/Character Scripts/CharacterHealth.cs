using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterHealth : GeneralEntitiesLife
{
    public Image healthBar;
    public GameObject defeatUI;
    public Animation anim;

    public override void TakeDamage(int amount)
    {
        //Ejecuta normalmente el TakeDamage, pero se le agrega la actualizacion de la barra de vida

        base.TakeDamage(amount);
        if (healthBar)
        {
            healthBar.fillAmount = (float)currentHitPoints / baseHitPoints;
        }
    }

    public void Heal(int amount)
    {
        //Curacion del personaje

        if (amount > 0 && currentHitPoints < baseHitPoints)
        {
            currentHitPoints += amount;
            if (currentHitPoints > baseHitPoints)
            {
                currentHitPoints = baseHitPoints;
                healthBar.fillAmount = (float)currentHitPoints / baseHitPoints;
            }
        }
    }

    public override void ZeroLife()
    {
        //Animacion de muerte 

    }

    public override void Death()
    {
        //Va a la pantalla de derrota
    }

}