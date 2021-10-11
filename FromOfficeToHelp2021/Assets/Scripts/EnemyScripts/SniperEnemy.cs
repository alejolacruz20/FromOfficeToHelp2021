using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy : MonoBehaviour
{
    public Transform playerPosition;
    public Transform shootingPoint;
    public GameObject bullet;
    public float chronometer;
    public float currentChronometer = 2;
    public bool throwing =  false;
    public Animator anim;

    private void Start()
    {
        
    }

    void Update()
    {
        Apuntado();
    }

    public void Apuntado()
    {
        if (Vector3.Distance(playerPosition.transform.position, transform.position) < 10)
        {
            transform.LookAt(new Vector3(playerPosition.transform.position.x, transform.position.y, playerPosition.transform.position.z));
            shootingPoint.LookAt(new Vector3(playerPosition.transform.position.x, playerPosition.transform.position.y, playerPosition.transform.position.z));

            if (throwing == false)
            {
                throwing = true;
                anim.SetBool("Throw", true);
            }
        }
    }

    public void Throwing()
    {
        Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
    }

    public void EndAnimation()
    {
        throwing = false;
        anim.SetBool("Throw", false);
    }
}
