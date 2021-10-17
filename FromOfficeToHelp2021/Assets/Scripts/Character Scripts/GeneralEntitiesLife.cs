using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEntitiesLife : MonoBehaviour
{
    public int baseHitPoints;
    public int currentHitPoints;
    public bool startChronometer;
    public float chronometer;
    public float limitChronometer;

    void Start()
    {
        startChronometer = false;
        currentHitPoints = baseHitPoints;
    }

    private void Update()
    {
        //Este chronometer es para dar tiempo a la entidad de hacer una animacion y despues destruirse, pero si hay algun problema o les gusta mas
        //tambien se puede hacer en la animacion de muerte del personaje o del enemigo, haciendo que al final de la animacion llame un evento de destruccion o de cambio de escena

        if (startChronometer == true)
        {
            chronometer += Time.deltaTime;
            if (chronometer >= limitChronometer)
            {
                Death();
            }
        }
    }


    public virtual void TakeDamage(int amount)
    {
        //Toma el daño de un golpe y lo resta a la vida, es virtual para que se pueda modificar en el script del personaje y se actualice el UI de la barra de vida

        if (amount > 0 && currentHitPoints > 0)
        {
            currentHitPoints -= amount;

            if (currentHitPoints <= 0)
            {
                ZeroLife();
            }

        }

    }

    public virtual void ZeroLife()
    {
        //Este evento es para cuando la entidad se queda sin vida, en cada script cambia haciendo que haga alguna animacion o algo así

        startChronometer = true;
    }

    public virtual void Death()
    {
        //Cuando el timer para se llama a esta funcion para destruir a la entidad o cambiar de escena en el caso del player

        Destroy(this.gameObject);
    }
}