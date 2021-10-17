using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Creador: Alejo Lacruz
public class CharacterAnimationInteraction : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] bulletSpawner;
    //public string buttonName = "Fire 1";
    public bool doingTheAnimation;
    public Animator characterAnimator;
    public float currentCronometer;
    public float cronometer = 1.5f;

    private void Start()
    {
        characterAnimator = GetComponent<Animator>();
        doingTheAnimation = false;
    }

    private void FixedUpdate()
    {
        cronometer += Time.deltaTime; //Tomamos como referencia para el enfriamiento
        InputCharacter();

        if (Input.GetKeyDown(KeyCode.E) && doingTheAnimation == false)
        {
            doingTheAnimation = true;
            characterAnimator.SetBool("Interact", true); //PIDE LA TECLA E Y PONE LA ANIMACIÓN DE INTERACT EN TRUE
        }

        if (Input.GetKeyDown(KeyCode.Q) && doingTheAnimation == false)
        {
            doingTheAnimation = true;
            characterAnimator.SetBool("Defense", true); //PIDE LA TECLA Q Y PONE LA ANIMACION DE DEFENSE EN TRUE
        }
    }

    public void Defensefinished() //Funcion para ponerlo en falso
    {
        doingTheAnimation = false;
        characterAnimator.SetBool("Defense", false);
    }

    public void InteractionFinished() //Funcion para ponerlo en falso
    {
        doingTheAnimation = false;
        characterAnimator.SetBool("Interact", false);
    }

    public void InputCharacter()
    {
        if (currentCronometer <= cronometer) //Enfriamiento
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
            Instantiate(bullet, bulletSpawner[i].position, bulletSpawner[i].rotation); //Instanciamos una bala
        }
    }

    public void AttackFinished() //Funcion para poner en falso el ataque
    {
        doingTheAnimation = false;
        characterAnimator.SetBool("Attack", false);
    }

}
