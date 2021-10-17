using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : GeneralEntitiesLife
{
    public Animator anim;
    public RandomMovement randomMovement;
    public Waypoints waypointMovement;
    public override void ZeroLife()
    {
        //Se cancela el movimiento
        if (randomMovement != null)
            randomMovement.enabled = false;
        else if (waypointMovement != null)
            waypointMovement.enabled = false;
        //Hace la animacion de muerte
        //Y sigue con el ZeroLife normal 
            base.ZeroLife();
    }

}
