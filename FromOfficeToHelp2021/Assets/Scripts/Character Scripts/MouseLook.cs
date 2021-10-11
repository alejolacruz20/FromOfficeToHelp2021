using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // CREADOR: LUCAS OLIVARES 

    public float MouseSensitivity = 100f;
    public Transform Playerbody;
    float _xRotation = 0f;
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // BLOQUEA EL CURSOR AL CENTRO DE LA PANTALLA 
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -45f, 45f); // BLOQUEA EL MOVIMIENDO DE LA CAMARA EN "Y"     
     
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f); 
        Playerbody.Rotate(Vector3.up * mouseX);
    }
}
