using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Creador: Lucas Olivares y Tiago Zedde
public class DashController : MonoBehaviour
{
    CharacterMovement MoveScript;

    public float DashSpeed;
    public float DashTime;
    public float dash_Timer;
    public float current_dashTimer;
    public bool canDash;


    // Start is called before the first frame update
    void Start()
    {
        MoveScript = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        dash_Timer += Time.deltaTime;
        if (dash_Timer > current_dashTimer)
        {
            canDash = true;
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        if (canDash)
        {
            canDash = false;
            dash_Timer = 0f;
            float StartTime = Time.time;
            FindObjectOfType<AudioManager>().Play("Dash");
            while (Time.time < StartTime + DashTime)
            {
                MoveScript.controller.Move(MoveScript.MoveDirection * DashSpeed * Time.deltaTime);

                yield return null;
            }
        }
    }
}
