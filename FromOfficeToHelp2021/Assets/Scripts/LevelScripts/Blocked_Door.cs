using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creador: Alejo Lacruz
public class Blocked_Door : MonoBehaviour
{
    public Animator anim;
    public bool inside = false;
    bool door;
    public static bool taken = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider target)
    {
        if(target.tag == "Player")
        {
            inside = true;
        }
    }

    private void OnTriggerExit(Collider target)
    {
        if(target.tag == "Player")
        {
            inside = false;
        }
    }

    private void Update()
    {
        if (inside && Input.GetKeyDown(KeyCode.E) && taken)
        {
            door = !door;
            FindObjectOfType<AudioManager>().Play("UnlockDoor");
        }
        if (door)
        {
            anim.SetBool("abierta", true);
        }
        else
        {
            anim.SetBool("abierta", false);

        }
    }  
}
