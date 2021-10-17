using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : GeneralEntitiesLife
{
    public Animator anim;
    public RandomMovement randomMovement;

    public override void ZeroLife()
    {
        //Se cancela el movimiento
        randomMovement.enabled = false;
        //Hace la animacion de muerte
        //Y sigue con el ZeroLife normal 
        base.ZeroLife();
    }

}
