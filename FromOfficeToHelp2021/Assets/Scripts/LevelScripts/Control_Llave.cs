using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creador: Alejo Lacruz
public class Control_Llave : MonoBehaviour
{
    public bool inside;
    public Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider target)
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
        if(inside && Input.GetKeyDown(KeyCode.E))
        {
            Blocked_Door.taken = true;
            rend.gameObject.SetActive(false);
        }
    }
}
