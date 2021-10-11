using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Creador: Alejo Lacruz
public class CharacterAnimationDefense : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Q) && doingTheAnimation == false)
        {
            doingTheAnimation = true;
            characterAnimator.SetBool("Defense", true);
        }
    }

    public void DefenseFinished()
    {
        doingTheAnimation = false;
        characterAnimator.SetBool("Defense", false);
    }
}
