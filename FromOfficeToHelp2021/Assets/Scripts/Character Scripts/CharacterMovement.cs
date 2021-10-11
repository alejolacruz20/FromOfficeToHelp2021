using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CREADOR: LUCAS OLIVARES

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public Vector3 MoveDirection;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

       MoveDirection = transform.right * x + transform.forward * z; //Movimiento en base a la direccion de la camara

        controller.Move(MoveDirection * speed * Time.deltaTime);
    }
}



