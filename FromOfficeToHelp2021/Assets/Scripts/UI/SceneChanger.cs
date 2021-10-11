using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Creador: Tiago Zedde
public class SceneChanger : MonoBehaviour
{
    public bool victory = false;
    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Victory");
        }
    }
    public void Exit() //Cerrar el juego
    {
        Application.Quit();
    }

    public void ChangesScene(string word) //Cambiar de Escena
    {
        SceneManager.LoadScene(word);
    }
}
