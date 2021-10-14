using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//Creador: Federico Paradiso
public class CharacterHealth : MonoBehaviour
{
    public int baseHitPoints = 5;
    public int currentHitPoints;
    public Image healthBar;
    public GameObject defeatUI;
    public bool destroy = true;
    public Animator deathanim;
    public AudioSource characterDamage;
    //public int amount;

    void Start()
    {
        deathanim = GetComponent<Animator>();
        currentHitPoints = baseHitPoints;
    }

    public void Update()
    {
        //TakeDamage(amount);
    }

    public void TakeDamage(int amount)
    {
        if (amount > 0 && currentHitPoints > 0)
        {
            currentHitPoints -= amount;

            if (healthBar)
            {
                healthBar.fillAmount = (float)currentHitPoints / baseHitPoints;
                FindObjectOfType<AudioManager>().Play("CharacterDMG");

            }

            if(currentHitPoints <= 0)
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("Defeat");
            }
            //if (currentHitPoints <= 0)
            //{
            //    if (defeatUI != null)
            //    {
            //        defeatUI.SetActive(true);
            //    }
            //}
        }
        //else 
        //{
        //    SceneManager.LoadScene("Menu");
        //}
    }

    public void Heal(int amount)
    {
        if (amount > 0 && currentHitPoints < baseHitPoints)
        {
            currentHitPoints += amount;
            if (currentHitPoints > baseHitPoints)
            {
                currentHitPoints = baseHitPoints;
                healthBar.fillAmount = (float)currentHitPoints / baseHitPoints;
            }
        }
    }

    public void Disappear()
    {
        Destroy(this.gameObject);
    }
}