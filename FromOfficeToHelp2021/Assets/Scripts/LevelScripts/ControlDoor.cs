using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creador: Alejo Lacruz
public class ControlDoor : MonoBehaviour
{
    Animator anim;
    bool Dentro = false;
    bool puerta;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        {
            Dentro = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
       if(col.tag == "Player")
       {
           Dentro = true;
       }
    }

    private void Update()
    {
        if(Dentro && Input.GetKeyDown(KeyCode.E))
        {
            puerta = !puerta;
            FindObjectOfType<AudioManager>().Play("OpenDoor");
        }
        if(puerta)
        {
            anim.SetBool("OpenDoor", true);
        }
        else
        {
            anim.SetBool("OpenDoor", false);
        }
    }
}
