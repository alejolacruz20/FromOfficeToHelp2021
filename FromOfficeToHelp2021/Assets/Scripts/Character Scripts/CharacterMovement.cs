using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CREADOR: LUCAS OLIVARES

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public float baseSpeed = 12f;
    public float speed;
    public Vector3 MoveDirection;

    private void Start()
    {
        speed = baseSpeed;
    }

    public void SpeedVariation(float amount) //Pedimos un valor para saber cuanta velocidad tenemos
    {
        if (amount > 0)
        {
            speed -= baseSpeed * amount;
            //startChronometer = true;
        }
        else
        {
            speed = baseSpeed;
        }

    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

       MoveDirection = transform.right * x + transform.forward * z; //Movimiento en base a la direccion de la camara

        controller.Move(MoveDirection * speed * Time.deltaTime);
    }
}



