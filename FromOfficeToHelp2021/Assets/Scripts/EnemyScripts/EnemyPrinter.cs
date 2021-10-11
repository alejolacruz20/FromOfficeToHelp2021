using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Creador: Tiago Zedde
public class EnemyPrinter : MonoBehaviour
{
    public Transform myTransform;
    public float min_Y, max_Y;
    public GameObject[] object_Prefabs;
    public GameObject enemyPrefab;
    public float angle;
    public float timer = 2f;
    public float waves = 1f;
    void Start()
    {

    }
    void Update()
    {
        SpawnEnemies();
    }
    void SpawnEnemies()
    {
        if (timer >= waves)
        {
            float pos_Y = Random.Range(min_Y, max_Y);
            Vector3 temp = transform.position;
            temp.y = pos_Y;
            if (Random.Range(0, 2) > 0)
            {
                Instantiate(object_Prefabs[Random.Range(0, object_Prefabs.Length)], temp, myTransform.rotation);
            }
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}