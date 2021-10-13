using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public bool activated;
    public bool analyzed;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.red);
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.gameObject.CompareTag("PlayerBullet"))
        {
            activated = true;
            rend.material.SetColor("_Color", Color.green);
        }
    }
}
