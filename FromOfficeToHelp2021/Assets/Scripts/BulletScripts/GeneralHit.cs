using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralHit : MonoBehaviour
{
    public int damage = 1;

    public virtual void OnTriggerEnter(Collider target)
    {
        //Asi como esta funciona para un golpe mele
        //Cuando choca con algo le pude su componente GeneralEntitiesLife,
        //que al ser el padre de la vida del personaje y la vida del enemigo
        //los reconoce como que tiene el componente GeneralEntitiesLife 
        //La manera de que la bala ddl enemigo no le pegue al enemigo seria con layers
        var hitObject = target.GetComponent<GeneralEntitiesLife>();
       
        if (hitObject != null)
        {
            hitObject.TakeDamage(damage);
        }
    }
}