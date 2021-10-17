using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//Creador: Federico Paradiso
public class CharacterHealth : GeneralEntitiesLife
{
    #region VARIABLES
    public Image healthBar;
    public GameObject defeatUI;
    public bool destroy = true;
    public Animator deathanim;
    public AudioSource characterDamage;
    #endregion
    #region CODIGO
    void Start()
    {
        deathanim = GetComponent<Animator>();
        currentHitPoints = baseHitPoints;
    }

    public override void TakeDamage(int amount) //Pedimos un int para saber cuanto daño nos hacen
    {
        if (amount > 0 && currentHitPoints > 0) //Vida mayor a cero
        {
            currentHitPoints -= amount;

            if (healthBar)
            {
                healthBar.fillAmount = (float)currentHitPoints / baseHitPoints;
                FindObjectOfType<AudioManager>().Play("CharacterDMG");

            }

            if(currentHitPoints <= 0) //Vida igual o menor a cero, muerto
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("Defeat");
            }
        }
 
    }
    // NO BORRAR ESTO!!! - -  - - --  - - - -- - - - - - - - - - - - -  -


    // - - - - - - - - -- - - - - - - - - - - - - - - -  - - - - - - - - - - - -
    //public void Heal(int amount) //Pedimos un valor entero para saber cuanto curarnos
    //{
    //    if (amount > 0 && currentHitPoints < baseHitPoints) //Condición para no pasarnos del máximo
    //    {
    //        currentHitPoints += amount;
    //        if (currentHitPoints > baseHitPoints)
    //        {
    //            currentHitPoints = baseHitPoints;
    //            healthBar.fillAmount = (float)currentHitPoints / baseHitPoints;
    //        }
    //    }
    //}
    #endregion
}