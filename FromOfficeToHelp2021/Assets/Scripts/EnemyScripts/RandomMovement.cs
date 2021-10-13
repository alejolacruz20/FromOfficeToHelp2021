using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creador: Gabriel Ceriani
public class RandomMovement : MonoBehaviour
{
    public int routine;
    public float chronometer;
    public Quaternion angle;
    public float degree;
    public GameObject target;
    public Animator movementAndAttack;
    public bool inAttack;
    public float walkSpeed;
    public float runSpeed;
    /*public float damage;
    public float damageChronometer;*/

    private void Start()
    {
        movementAndAttack = GetComponent<Animator>();
        target = GameObject.Find("Character");
    }

    void Update()
    {
        EnemyBehaviour();
    }

    public void EnemyBehaviour()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 10)
        {
            movementAndAttack.SetBool("Run", false);

            chronometer += 1 * Time.deltaTime;
            if (chronometer >= 3)
            {
                routine = Random.Range(0, 2);
                chronometer = 0;
                /*if (routine == 2)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                }
                else if(routine == 1)
                {
                    degree = Random.Range(0, 360f);
                    angle = Quaternion.Euler(0, degree, 0);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                }*/
            }
            switch (routine)
            {
                case 0:
                    movementAndAttack.SetBool("Walk", false);
                    break;

                case 1:
                    degree = Random.Range(0, 360f);
                    angle = Quaternion.Euler(0, degree, 0);
                    routine++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 5);
                    transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
                    movementAndAttack.SetBool("Walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 5 && !inAttack == false)
            {
                movementAndAttack.SetBool("Attack", false);
                var lookPosition = target.transform.position - transform.position;
                lookPosition.y = 0;
                var rotation = Quaternion.LookRotation(lookPosition);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                movementAndAttack.SetBool("Walk", false);
                transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
                movementAndAttack.SetBool("Run", true);

            }
            else
            {
                /*damageChronometer += 1 * Time.deltaTime;
                if (damageChronometer >= 1)
                {
                    Debug.Log("Daño causado =" + damage);
                    damageChronometer = 0;
                }*/

                var lookPosition = target.transform.position - transform.position;
                lookPosition.y = 0;
                var rotation = Quaternion.LookRotation(lookPosition);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                movementAndAttack.SetBool("Walk", false);
                movementAndAttack.SetBool("Run", false);
                movementAndAttack.SetBool("Attack", true);
                inAttack = true;
            }
        }

    }

    public void AnimationEnd()
    {
        movementAndAttack.SetBool("Attack", false);
        inAttack = false;
    }
}
