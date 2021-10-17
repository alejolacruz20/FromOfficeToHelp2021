using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : GeneralHit
{
    //Por la herencia tiene el OntriggerEnter 
    //Lo unico que se agrega aca es el movimiento de la bala
    public float speed;
    public override void OnTriggerEnter(Collider target)
    {
        base.OnTriggerEnter(target);
        Destroy(this.gameObject);
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

}