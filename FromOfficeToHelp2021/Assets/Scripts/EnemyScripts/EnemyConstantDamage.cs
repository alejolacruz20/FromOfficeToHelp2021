using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Creador: Gabriel Ceriani
public class EnemyConstantDamage : MonoBehaviour
{
    public int damage;
    public float chronometer;
    public GameObject target;
    public int interactiveActions;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        AttackeDetection();
    }

    public void AttackeDetection()
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
                break;

            case 1:
                //Debug.Log(damage + " de Daño"); 
                chronometer += 1 * Time.deltaTime;
                if (chronometer >= 2)
                {
                    //target.GetComponent<EnemyLife>().ColorChangeDamage(damage);
                    target.GetComponent<CharacterHealth>().TakeDamage(damage);
                    Debug.Log(damage + " de daño");
                    chronometer = 0;
                }
                break;

            case 2:
                break;

        }
    }
}
