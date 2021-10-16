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

        if (Vector3.Distance(target.transform.position, transform.position) < 2 && splash == false) //Preguntamos si está dentro de la distancia pedida
        {
            splash = true;
            coffe.SetActive(true); //Ponemos el charco de cafe en true
        }
    }

    private void CoffeSplashOff()
    {
        splash = false;
        coffe.SetActive(false); //Ponemos el charco de cafe en false
    }
}
