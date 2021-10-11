using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Creador: Gabriel Ceriani y Tiago Zedde
public class CharacterAnimationShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] bulletSpawner;
    //public string buttonName = "Fire 1";
    public bool doingTheAnimation;
    public Animator characterAnimator;
    public float currentCronometer;
    public float cronometer = 1f;

    private void Start()
    {
        characterAnimator = GetComponent<Animator>();
        doingTheAnimation = false;
    }

    private void Update()
    {
        cronometer += Time.deltaTime;
        InputCharacter();
    }

    public void InputCharacter()
    {
        if(currentCronometer <= cronometer)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && doingTheAnimation == false) // Dentro del Update llamar a esta funcion 
            {
                doingTheAnimation = true;
                characterAnimator.SetBool("Attack", true);
                cronometer = 0f;
            }
        }
    }

    public void AnimationShooting()
    {
        for (int i = 0; i < bulletSpawner.Length; i++)
        {
            Instantiate(bullet, bulletSpawner[i].position, bulletSpawner[i].rotation);
        }
    }

    public void AttackFinished()
    {
        doingTheAnimation = false;
        characterAnimator.SetBool("Attack", false);
    }

}
