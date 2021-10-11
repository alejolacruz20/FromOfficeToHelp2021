using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    public string buttonName = "Fire1";
    public GameObject disparoPrefab;
    public Transform[] shootingPoints;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(buttonName))
        {
            FindObjectOfType<AudioManager>().Play("Shoot");

            for (int i = 0; i < shootingPoints.Length; i++)
            {
                Instantiate(disparoPrefab, shootingPoints[i].position, shootingPoints[i].rotation);
            }
        }
    }
}
