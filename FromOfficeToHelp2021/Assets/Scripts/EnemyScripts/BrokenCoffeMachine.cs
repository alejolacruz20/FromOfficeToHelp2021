using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Creador: Gabriel Ceriani
public class BrokenCoffeMachine : MonoBehaviour
{
    public bool splash;
    public GameObject target;
    public GameObject coffe;

    private void Start()
    {
        coffe.SetActive(false);
        target = GameObject.Find("Character");
    }

    private void Update()
    {

        if (Vector3.Distance(target.transform.position, transform.position) < 2 && splash == false)
        {
            splash = true;
            coffe.SetActive(true);
        }
    }

    private void CoffeSplashOff()
    {
        splash = false;
        coffe.SetActive(false);
    }
}
