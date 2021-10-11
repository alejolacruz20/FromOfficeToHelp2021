using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Creador: Alejo Lacruz
public class CharacterAnimationInteraction : MonoBehaviour
{
    public bool doingTheAnimation;
    public Animator characterAnimator;

    private void Start()
    {
        characterAnimator = GetComponent<Animator>();
        doingTheAnimation = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && doingTheAnimation == false)
        {
            doingTheAnimation = true;
            characterAnimator.SetBool("Interact", true);
        }
    }

    public void InteractionFinished()
    {
        doingTheAnimation = false;
        characterAnimator.SetBool("Interact", false);
    }
}
