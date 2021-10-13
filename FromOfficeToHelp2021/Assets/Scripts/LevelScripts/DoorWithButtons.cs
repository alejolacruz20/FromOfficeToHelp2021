using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithButtons : MonoBehaviour
{
    public GameObject[] buttons;
    Buttons activatedButtons;
    public List<GameObject> activatedButtonsList;
    public Animator anim;

    void Start()
    {

    }

    void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            activatedButtons = buttons[i].GetComponent<Buttons>();
            if (activatedButtons.analyzed == false)
            {
                if (activatedButtons.activated == true)
                {
                    activatedButtonsList.Add(buttons[i]);
                    activatedButtons.analyzed = true;
                }
            }
        }

        if (buttons.Length == activatedButtonsList.Count)
        {
            anim.SetBool("OpenFinalDoor", true);
        }
    }
}
