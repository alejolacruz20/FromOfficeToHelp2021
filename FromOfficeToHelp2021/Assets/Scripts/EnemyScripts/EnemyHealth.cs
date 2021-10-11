using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Creador: Gabriel Ceriani
public class EnemyHealth : MonoBehaviour
{
    public int maxHitPoints;
    public int currentHitPoints;
    public bool isTheBoss;
    public float chronometer;
    public float limitChronometer = 1.2f;
    public Animator anim;
    public RandomMovement enemyRandomMovement;
    public Waypoints enemyWaypointMovement;

    void Start()
    {
        currentHitPoints = maxHitPoints;
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
                    Cursor.lockState = CursorLockMode.None;
                    SceneManager.LoadScene("Victory");
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

                    //if (chronometer >= limitChronometer)
                    //{
                    //   Destroy(this.gameObject);
                    //}
                }
            }
        }
    }
}
