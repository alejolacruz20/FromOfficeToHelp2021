using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    //Creador: Gabriel Ceriani

    public int openSide;
    private RoomTemplates templates;
    private int random;
    public bool spawned = false;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }


    void Spawn()
    {
        if (spawned == false)
        {
            if (openSide == 1)
            {
                random = Random.Range(0, templates.downRoom.Length);
                Instantiate(templates.downRoom[random], transform.position, templates.downRoom[random].transform.rotation);
            }
            else if (openSide == 2)
            {
                random = Random.Range(0, templates.topRoom.Length);
                Instantiate(templates.topRoom[random], transform.position, templates.topRoom[random].transform.rotation);
            }
            else if (openSide == 3)
            {
                random = Random.Range(0, templates.leftRoom.Length);
                Instantiate(templates.leftRoom[random], transform.position, templates.leftRoom[random].transform.rotation);
            }
            else if (openSide == 4)
            {
                random = Random.Range(0, templates.rightRoom.Length);
                Instantiate(templates.rightRoom[random], transform.position, templates.rightRoom[random].transform.rotation);
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Detector"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Detector"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<RoomSpawner>())
        {
            Destroy(this.gameObject);
        }
    }
}
