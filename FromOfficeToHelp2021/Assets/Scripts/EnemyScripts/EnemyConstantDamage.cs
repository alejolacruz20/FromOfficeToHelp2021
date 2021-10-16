using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creador: Gabriel Ceriani
public class EnemyConstantDamage : MonoBehaviour
{
    public int damage;
    public float slowDownLimitChronometer;
    public bool startChronometer;
    public float chronometer;
    public float damageLimitChronometer;
    public float chronometerSlowdown;
    public GameObject target;
    public int interactiveActions;
    public float slowdownAmount;
    public bool slowedDown;
    public EnemyHealth enemyLife;
    CharacterMovement targetMovement;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Character");
        targetMovement = target.GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyLife.currentHitPoints <= 0)
        {
            targetMovement.SpeedVariation(0f);
        }

        AttackDetection();

        if (startChronometer == true)
        {
            chronometerSlowdown += Time.deltaTime;

            if (chronometerSlowdown >= slowDownLimitChronometer)
            {
                targetMovement.SpeedVariation(0f);
                slowedDown = false;
                chronometerSlowdown = 0; //si se iguala a cero cuando el cronometro termina hace que cuendo el jugador salga del area de relentizacion siga con velocidad reducida hasta que termine el ultimo cronometro, si no se iguala automaticamente vuelve a la normalidad
            }
        }
    }

    public void AttackDetection()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= 6 && Vector3.Distance(transform.position, target.transform.position) > 4)
        {
            interactiveActions = 0;
        }
        else if (Vector3.Distance(transform.position, target.transform.position) <= 4)
        {
            interactiveActions = 1;
        }
        else
        {
            interactiveActions = 2;
        }

        switch (interactiveActions)
        {
            case 0:
                //Debug.Log("Relentizado");
                if (slowedDown == false)
                {
                    //Bullet targetMovement = target.GetComponent<Bullet>();
                    targetMovement.SpeedVariation(slowdownAmount);
                    Debug.Log("Relentizado");
                    slowedDown = true;
                    startChronometer = true;
                }

                break;

            case 1:
                //Debug.Log(damage + " de Daño"); 
                if (slowedDown == false)
                {
                    //Bullet targetMovement = target.GetComponent<Bullet>();
                    targetMovement.SpeedVariation(slowdownAmount);
                    Debug.Log("Relentizado");
                    slowedDown = true;
                    startChronometer = true;
                }

                chronometer += Time.deltaTime;

                if (chronometer >= damageLimitChronometer)
                {
                    chronometer = 0;
                    //target.GetComponent<EnemyLife>().ColorChangeDamage(damage);
                    target.GetComponent<CharacterHealth>().TakeDamage(damage);
                    Debug.Log(damage + " de daño");
                }
                break;

            case 2:
                break;
        }
    }
}
