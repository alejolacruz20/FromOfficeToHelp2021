using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : GeneralEntitiesLife
{
    public Animator anim;
    public GameObject victoryZone;
    public override void ZeroLife()
    {
        victoryZone.SetActive(true);
        Death();
    }

}
