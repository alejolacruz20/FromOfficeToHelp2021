using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Creador: Gabriel Ceriani
public class EnemyHealth : GeneralEntitiesLife
{
    #region VARIABLES
    public int maxHitPoints;
    public bool isTheBoss;
    public Animator anim;
    public RandomMovement enemyRandomMovement;
    public Waypoints enemyWaypointMovement;
    public GameObject victoryZone;
    #endregion
    #region CODIGO
    void Start()
    {
        currentHitPoints = maxHitPoints;
        victoryZone.SetActive(false);
    }

    private void Update()
    {
        if(currentHitPoints <= 0)
        {
            chronometer += Time.deltaTime;

            if (chronometer >= limitChronometer)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void ColorChangeDamage(int amount)
    {
        if (amount >= 1)
        {
            currentHitPoints -= amount;

            if (currentHitPoints <= 0)
            {
                if (isTheBoss == true)
                {
                    Debug.Log("EnemigoMuerto");
                    FindObjectOfType<AudioManager>().Play("DeathEnemy");
                    Destroy(this.gameObject);
                    victoryZone.SetActive(true);
                }
                else
                {
                    Debug.Log("EnemigoMuerto");
                    FindObjectOfType<AudioManager>().Play("DeathEnemy");
                    anim.SetBool("Freedom", true);

                    if (enemyWaypointMovement != null)
                    {
                        enemyWaypointMovement.enabled = false;
                    }
                    else if (enemyRandomMovement != null)
                    {
                        enemyRandomMovement.enabled = false;
                    }
                }
            }
        }
    }
    #endregion
}
